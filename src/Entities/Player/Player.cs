using Godot;
using System;

public class Player : KinematicBody2D
{
    [Export] public int jumpForce = 1280;
    [Export] public int movementSpeed = 700;
    [Export] public float maxJumpTime = 0.04f;
    [Export] public float maxFallSpeed = 1280;
    [Export] public int gravity = 210;
    public Area2D jumpObjectCollisionCheck;
    public Area2D teleportCollisionCheck;
    public Timer secondaryActionTimer;
    public Timer mainActionTimer;
    public Timer startTimer;
    public bool blocked;
    public bool invertedGravity = false;
    public bool invincible;
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

    [Signal]
    public delegate void Dead();

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

        if (this.invertedGravity)
            this.invertGravity();
            
        this.Visible = true;
        this.blocked = true;
        this.invincible = false;
        this.jumpForce = this.DEFAULT_JUMPFORCE;
        this.maxFallSpeed = this.DEFAULT_JUMPFORCE;
        this.gravity = this.DEFAULT_GRAVITY;
        this.maxJumpTime = this.DEFAULT_MAX_JUMP_TIME;
        this.movementSpeed = this.DEFAULT_MOVEMENT_SPEED;
        this.linearVelocity = new Vector2(0, 0);
    }

    public override void _PhysicsProcess(float delta)
    {
        /*if (this.IsOnWall())
            GD.Print("On wall");

        if (this.IsOnCeiling())
            GD.Print("On ceiling");

        GD.Print(this.invertedGravity);*/

        this.persistentState._StatePhysicsProcess(delta);
        this.mainAction._StatePhysicsProcess(delta);
        this.secondaryAction._StatePhysicsProcess(delta);

        if (this.invertedGravity)
            this.MoveAndSlide(this.linearVelocity, Vector2.Down, floorMaxAngle: Mathf.Deg2Rad(60));
        else
            this.MoveAndSlide(this.linearVelocity, Vector2.Up);
    }

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

    public void ChangeMainAction(PlayerMainAction action)
    {
        if (this.mainAction != null)
        {
            this.mainAction.QueueFree();
        }

        this.mainAction = this.stateFactory.New(action);
        this.AddChild(this.mainAction);
        this.mainAction.Setup();
    }

    public void ChangeSecondaryAction(PlayerSecondaryAction action)
    {
        if (this.secondaryAction != null)
        {
            this.secondaryAction.QueueFree();
        }

        this.secondaryAction = this.stateFactory.New(action);
        this.AddChild(this.secondaryAction);
        this.secondaryAction.Setup();
    }

    public void invertGravity()
    {
        this.animation.FlipV = !this.animation.FlipV;
        this.invertedGravity = !this.invertedGravity;
        this.runningCollision.Position = new Vector2(this.runningCollision.Position.x, -this.runningCollision.Position.y);
        this.rollingCollision.Position = new Vector2(this.rollingCollision.Position.x, -this.rollingCollision.Position.y);
        this.jumpForce = -this.jumpForce;
        this.gravity = -this.gravity;

        if (this.mainAction is Teleport)
        {
            ((Teleport) this.mainAction).TELEPORT_DISTANCE = -((Teleport) this.mainAction).TELEPORT_DISTANCE;
        }
    }

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
        this.blocked = false;
    }
}
