using Godot;
using System;

/// <summary>
///     The player node.
///     It is a state machine that executes 3 states at each given time.
///     The first state is a physical state (On ground, on air), while the other 2 are actions that the player can perform at a given time (Kind of like powers).
/// </summary>
public class Player : KinematicBody2D
{
    /// <summary>
    ///     The force/speed of the player's jump.
    /// </summary>
    [Export] public int JumpForce = 1280;

    /// <summary>
    ///     The player's movement speed.
    /// </summary>
    [Export] public int MovementSpeed = 700;

    /// <summary>
    ///     The maximum duration of the player's jump.
    /// </summary>
    [Export] public float MaxJumpTime = 0.04f;

    /// <summary>
    ///     The maximum falling speed of the player.
    /// </summary>
    [Export] public float MaxFallSpeed = 1280;

    /// <summary>
    ///     The player's gravity. This gets added each frame to the player's vertical linear velocity.
    /// </summary>
    [Export] public int Gravity = 210;

    /// <summary>
    ///     Male character animations
    /// </summary>
    [Export] public SpriteFrames MaleAnimation;

    /// <summary>
    ///     Female character animations
    /// </summary>
    [Export] public SpriteFrames FemaleAnimation;

    /// <summary>
    ///     Emitted if the player dies.
    /// </summary>
    [Signal]
    public delegate void Dead();

    /// <summary>
    ///     Emitted when the player performs a main action.
    /// </summary>
    [Signal]
    public delegate void PerformedMainAction();

    /// <summary>
    ///     Emitted when the player comes in contact with a pickup.
    /// </summary>
    [Signal]
    public delegate void Pickup();

    /// <summary>
    ///     Area2D to check if the player has entered any jump objects.
    /// </summary>
    public Area2D jumpObjectCollisionCheck;

    /// <summary>
    ///     Area2D to check if the player will die on teleport.
    /// </summary>
    public Area2D teleportCollisionCheck;

    /// <summary>
    ///     Timer to perform event after a secondary action was executed.
    /// </summary>
    public Timer secondaryActionTimer;

    /// <summary>
    ///     Timer to perform event after a main action was executed.
    /// </summary>
    public Timer mainActionTimer;

    /// <summary>
    ///     This timer enables input on the player on timeout.
    /// </summary>
    public Timer startTimer;

    /// <summary>
    ///     The player's animation.
    /// </summary>
    public AnimatedSprite animation;

    /// <summary>
    ///     The player's default collision shape.
    /// </summary>
    public CollisionShape2D runningCollision;

    /// <summary>
    ///     The player's collision shape while performing a roll action.
    /// </summary>
    public CollisionShape2D rollingCollision;

    /// <summary>
    ///     The player's linear velocity vector.
    /// </summary>
    public Vector2 linearVelocity = new Vector2(0, 0);

    // Default constants.
    public readonly int DEFAULT_JUMPFORCE = 1280;
    public readonly int DEFAULT_GRAVITY = 210;
    public readonly int DEFAULT_MOVEMENT_SPEED = 700;
    public readonly float DEFAULT_MAX_JUMP_TIME = 0.04f;

    /// <summary>
    ///     Factory for creating new player state instances.
    /// </summary>
    private PlayerStateFactory stateFactory;

    /// <summary>
    ///     The current persistent state of the player.
    /// </summary>
    public PersistentState PersistentState { get; set; }

    /// <summary>
    ///     The main action the player can currently perform.
    /// </summary>
    public MainAction MainAction { get; set; }

    /// <summary>
    ///     The secondary action the player can currently perform.
    /// </summary>
    public SecondaryAction SecondaryAction { get; set; }

    /// <summary>
    ///     The type of the main action that the player can currently execute.
    /// </summary>
    public PlayerMainAction MainActionType { get; set; }

    /// <summary>
    ///     The type of the secondary action that the player can currently execute.
    /// </summary>
    public PlayerSecondaryAction SecondaryActionType { get; set; }

    /// <summary>
    ///     If true, then the player can't perform any actions.
    /// </summary>
    public bool Blocked { get; set; }

    /// <summary>
    ///     If true, then the player's gravity vector is inverted.
    /// </summary>
    public bool InvertedGravity { get; set; } = false;

    /// <summary>
    ///     If true, then the player can't die.
    /// </summary>
    public bool Invincible { get; set; } = false;


    public override void _Ready()
    {
        this.animation = this.GetNode<AnimatedSprite>("Animation");
        this.startTimer = this.GetNode<Timer>("StartTimer");
        this.secondaryActionTimer = this.GetNode<Timer>("SlideTimer");
        this.mainActionTimer = this.GetNode<Timer>("JumpTimer");
        this.jumpObjectCollisionCheck = this.GetNode<Area2D>("JumpObjectCollisionCheck");
        this.teleportCollisionCheck = this.GetNode<Area2D>("TeleportCollisionCheck");
        this.runningCollision = this.GetNode<CollisionShape2D>("RunningCollision");
        this.rollingCollision = this.GetNode<CollisionShape2D>("SlidingCollision");

        this.startTimer.Connect("timeout", this, nameof(this.OnStartTimerTimeout));

        if (PlayerSession.ActiveSession.Profile.Avatar.Male)
            this.animation.Frames = this.MaleAnimation;
        else
            this.animation.Frames = this.FemaleAnimation;

        if (PlayerSession.ActiveSession.Profile.Avatar.TopColor != 15)
            this.animation.Modulate = Palette.Instance.PaletteColors[PlayerSession.ActiveSession.Profile.Avatar.TopColor];
        else if (PlayerSession.ActiveSession.Profile.Avatar.BottomColor != 15)
            this.animation.Modulate = Palette.Instance.PaletteColors[PlayerSession.ActiveSession.Profile.Avatar.BottomColor];

        this.stateFactory = new PlayerStateFactory();
        this.ChangePersistentState(PlayerPersistentState.ON_GROUND);
        this.ChangeMainAction(PlayerMainAction.JUMP);
        this.ChangeSecondaryAction(PlayerSecondaryAction.FASTFALL_AND_ROLL);

        this.startTimer.Start();

        if (this.InvertedGravity)
            this.InvertGravity();
            
        this.Visible = true;
        this.Blocked = true;
        this.Invincible = false;
        this.JumpForce = this.DEFAULT_JUMPFORCE;
        this.MaxFallSpeed = this.DEFAULT_JUMPFORCE;
        this.Gravity = this.DEFAULT_GRAVITY;
        this.MaxJumpTime = this.DEFAULT_MAX_JUMP_TIME;
        this.MovementSpeed = this.DEFAULT_MOVEMENT_SPEED;
        this.linearVelocity = new Vector2(0, 0);
    }

    public override void _PhysicsProcess(float delta)
    {
        this.PersistentState._StatePhysicsProcess(delta);
        this.MainAction._StatePhysicsProcess(delta);
        this.SecondaryAction._StatePhysicsProcess(delta);

        if (this.InvertedGravity)
            this.MoveAndSlide(this.linearVelocity, Vector2.Down, floorMaxAngle: Mathf.Deg2Rad(60));
        else
            this.MoveAndSlide(this.linearVelocity, Vector2.Up, floorMaxAngle: Mathf.Deg2Rad(60));
    }

    /// <summary>
    ///     Changes the current persistent state.
    /// </summary>
    /// <param name="state">The new state.</param>
    public void ChangePersistentState(PlayerPersistentState state)
    {
        if (this.PersistentState != null)
        {
            this.PersistentState.QueueFree();
        }

        this.PersistentState = this.stateFactory.New(state);
        this.AddChild(this.PersistentState);
        this.PersistentState.Setup();
    }

    /// <summary>
    ///     Changes the current main action the player can perform.
    /// </summary>
    /// <param name="state">The new action.</param>
    public void ChangeMainAction(PlayerMainAction action)
    {
        if (this.MainAction != null)
        {
            this.MainAction.QueueFree();
        }

        this.MainActionType = action;
        this.MainAction = this.stateFactory.New(action);
        this.AddChild(this.MainAction);
        this.MainAction.Setup();
        this.MainAction.Connect("Action", this, nameof(this.OnMainAction));
    }

    /// <summary>
    ///     Changes the current secondary action the player can perform.
    /// </summary>
    /// <param name="state">The new action.</param>
    public void ChangeSecondaryAction(PlayerSecondaryAction action)
    {
        if (this.SecondaryAction != null)
        {
            this.SecondaryAction.QueueFree();
        }

        this.SecondaryActionType = action;
        this.SecondaryAction = this.stateFactory.New(action);
        this.AddChild(this.SecondaryAction);
        this.SecondaryAction.Setup();
    }

    /// <summary>
    ///     Invert's the player's gravity.
    /// </summary>
    public void InvertGravity()
    {
        this.animation.FlipV = !this.animation.FlipV;
        this.InvertedGravity = !this.InvertedGravity;
        this.runningCollision.Position = new Vector2(this.runningCollision.Position.x, -this.runningCollision.Position.y);
        this.rollingCollision.Position = new Vector2(this.rollingCollision.Position.x, -this.rollingCollision.Position.y);
        this.JumpForce = -this.JumpForce;
        this.Gravity = -this.Gravity;

        if (this.MainAction is Teleport)
        {
            ((Teleport) this.MainAction).TELEPORT_DISTANCE = -((Teleport) this.MainAction).TELEPORT_DISTANCE;
        }
    }

    /// <summary>
    ///     Sets a hitbox on the player depending on the state.
    /// </summary>
    /// <param name="state">The player's state.</param>
    public void SetHitbox(PlayerPersistentState state) {
        switch (state) {
            case PlayerPersistentState.ON_GROUND:
                this.GetNode<CollisionShape2D>("RunningCollision").SetDeferred("disabled", false);
                this.GetNode<CollisionShape2D>("SlidingCollision").SetDeferred("disabled", true);
                break;

            case PlayerPersistentState.ON_AIR:
                this.GetNode<CollisionShape2D>("RunningCollision").SetDeferred("disabled", true);
                this.GetNode<CollisionShape2D>("SlidingCollision").SetDeferred("disabled", false);
                break;
        }
    }

    public void OnStartTimerTimeout() {
        this.Blocked = false;
        this.startTimer.Stop();
    }

    public void OnMainAction()
    {
        this.EmitSignal("PerformedMainAction");
    }
}
