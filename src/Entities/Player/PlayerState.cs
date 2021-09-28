using System;
using Godot;

public abstract class PlayerState: Node2D {
    protected Player player;
    protected Area2D groundCollisionCheck;
    protected Area2D frontCollisionCheck;
    protected Area2D jumpObjectCollisionCheck;
    protected Timer slideTimer;
    protected Timer jumpTimer;
    protected AnimatedSprite animation;
    public int jumpForce = 80000;
    public int movementSpeed = 44000;
    public int topFallSpeed = 100000;
    public float maxJumpTime = 0.04f;
    public bool right = true;
    public int gravity = 10000;


    public void Setup()
    {
        this.player = this.GetParent<Player>();
        this.animation = this.player.GetNode<AnimatedSprite>("Animation");
        this.slideTimer = this.player.GetNode<Timer>("SlideTimer");
        this.jumpTimer = this.player.GetNode<Timer>("JumpTimer");
        this.groundCollisionCheck = this.player.GetNode<Area2D>("GroundCollisionCheck");
        this.jumpObjectCollisionCheck = this.player.GetNode<Area2D>("JumpObjectCollisionCheck");
        this.frontCollisionCheck = this.player.GetNode<Area2D>("FrontCollisionCheck");




        this._Init();
    }

    public override void _PhysicsProcess(float delta)
    {
        this._StatePhysicsProcess(delta);

        if (this.player.linearVelocity.y > -10000 && this.player.linearVelocity.y < 10000)
            this.player.linearVelocity.y += this.gravity / 5;
        else
            this.player.linearVelocity.y += this.gravity;

        this.player.MoveAndSlide(this.player.linearVelocity * delta, Vector2.Up);
    }

    public abstract void _Init();
    public abstract void _StatePhysicsProcess(float delta);

    public abstract string GetState();
}