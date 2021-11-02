using Godot;
using System;

/// <summary>
///     The player node.
///     It is a state machine that executes 3 states at each given time.
///     The first state is a physical state (On ground, on air), while the other 2 are actions that the player can perform at a given time (Kind of like powers).
/// </summary>
public class Player : KinematicBody2D
{
    [Export] public int JumpForce = 1280;
    [Export] public int MovementSpeed = 700;
    [Export] public float MaxJumpTime = 0.04f;
    [Export] public float MaxFallSpeed = 1280;
    [Export] public int Gravity = 210;

    [Signal]
    public delegate void Dead();

    public Area2D jumpObjectCollisionCheck;
    public Area2D teleportCollisionCheck;
    public Timer secondaryActionTimer;
    public Timer mainActionTimer;
    public Timer startTimer;
    public AnimatedSprite animation;
    public PersistentState persistentState;
    public MainAction mainAction;
    public SecondaryAction secondaryAction;
    public PlayerStateFactory stateFactory;
    public CollisionShape2D runningCollision;
    public CollisionShape2D rollingCollision;
    public Vector2 linearVelocity = new Vector2(0, 0);
    public readonly int DEFAULT_JUMPFORCE = 1280;
    public readonly int DEFAULT_GRAVITY = 210;
    public readonly int DEFAULT_MOVEMENT_SPEED = 700;
    public readonly float DEFAULT_MAX_JUMP_TIME = 0.04f;
    public PlayerMainAction mainActionType;
    public PlayerSecondaryAction secondaryActionType;

    public bool Blocked { get; set; }
    public bool InvertedGravity { get; set; } = false;
    public bool Invincible { get; set; }


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
        this.persistentState._StatePhysicsProcess(delta);
        this.mainAction._StatePhysicsProcess(delta);
        this.secondaryAction._StatePhysicsProcess(delta);

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
        if (this.persistentState != null)
        {
            this.persistentState.QueueFree();
        }

        this.persistentState = this.stateFactory.New(state);
        this.AddChild(this.persistentState);
        this.persistentState.Setup();
    }

    /// <summary>
    ///     Changes the current main action the player can perform.
    /// </summary>
    /// <param name="state">The new action.</param>
    public void ChangeMainAction(PlayerMainAction action)
    {
        if (this.mainAction != null)
        {
            this.mainAction.QueueFree();
        }

        this.mainActionType = action;
        this.mainAction = this.stateFactory.New(action);
        this.AddChild(this.mainAction);
        this.mainAction.Setup();
    }

    /// <summary>
    ///     Changes the current secondary action the player can perform.
    /// </summary>
    /// <param name="state">The new action.</param>
    public void ChangeSecondaryAction(PlayerSecondaryAction action)
    {
        if (this.secondaryAction != null)
        {
            this.secondaryAction.QueueFree();
        }

        this.secondaryActionType = action;
        this.secondaryAction = this.stateFactory.New(action);
        this.AddChild(this.secondaryAction);
        this.secondaryAction.Setup();
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

        if (this.mainAction is Teleport)
        {
            ((Teleport) this.mainAction).TELEPORT_DISTANCE = -((Teleport) this.mainAction).TELEPORT_DISTANCE;
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
                
                this.GetNode<CollisionShape2D>("RunningCollision").SetDeferred("disabled", false);
                this.GetNode<CollisionShape2D>("SlidingCollision").SetDeferred("disabled", true);
                break;

            case PlayerPersistentState.SECONDARY_ACTION:
                this.GetNode<CollisionShape2D>("RunningCollision").SetDeferred("disabled", true);
                this.GetNode<CollisionShape2D>("SlidingCollision").SetDeferred("disabled", false);
                break;
        }
    }

    public void OnStartTimerTimeout() {
        this.Blocked = false;
        this.startTimer.Stop();
    }
}
