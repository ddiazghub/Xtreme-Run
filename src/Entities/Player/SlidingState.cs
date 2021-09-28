using Godot;
using System;

public class SlidingState: PlayerState {


    public override void _Init()
    {
        this.animation.Play("sliding");
        
        this.frontCollisionCheck.Connect("body_entered", this, nameof(this.OnFrontCollisionCheckBodyEntered));
        this.jumpObjectCollisionCheck.Connect("area_entered", this, nameof(this.OnJumpObjectCollisionCheckAreaEntered));
        
        this.frontCollisionCheck.GetNode<CollisionShape2D>("RunningCollisionShape").Disabled = true;
        this.frontCollisionCheck.GetNode<CollisionShape2D>("SlidingCollisionShape").Disabled = false;
        this.frontCollisionCheck.GetNode<CollisionShape2D>("JumpingCollisionShape").Disabled = true;
        this.player.GetNode<CollisionShape2D>("RunningCollision").Disabled = true;
        this.player.GetNode<CollisionShape2D>("SlidingCollision").Disabled = false;

        this.slideTimer.Connect("timeout", this, nameof(this.OnSlideTimerTimeout));
        this.slideTimer.Start();
    }

    public override void _StatePhysicsProcess(float delta)
    {
        if (this.right)
            this.player.linearVelocity.x = this.movementSpeed;
        else
            this.player.linearVelocity.x = -this.movementSpeed;
    }

    public void OnFrontCollisionCheckBodyEntered(Node body)
    {
        if (body.IsInGroup("solid"))
        {
            this.player.EmitSignal("Dead");
        }
    }

    public void OnJumpObjectCollisionCheckAreaEntered(Area2D area)
    {
        /*
        if (area.IsInGroup("jump"))
        {
            this._onJumpObject = true;
        }
        */

        if (area.IsInGroup("jump_auto"))
        {
            this.player.ChangeState(PlayerStates.JUMPING);
        }
    }

    public void OnSlideTimerTimeout()
    {
        if (this.player.IsOnFloor())
            this.player.ChangeState(PlayerStates.RUNNING);
        else
            this.player.ChangeState(PlayerStates.JUMPING);
    }

    public override string GetState()
    {
        return "Sliding";
    }
}