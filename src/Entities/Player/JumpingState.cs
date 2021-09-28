using Godot;
using System;

public class JumpingState: PlayerState {
    private bool onJumpPad = false;
    private bool jumping = true;


    public override void _Init()
    {
        this.animation.Play("running");
        this.jumpObjectCollisionCheck.Connect("area_entered", this, nameof(this.OnJumpObjectCollisionCheckAreaEntered));
        this.jumpObjectCollisionCheck.Connect("area_exited", this, nameof(this.OnJumpObjectCollisionCheckAreaExited));
        this.frontCollisionCheck.Connect("body_entered", this, nameof(this.OnFrontCollisionCheckBodyEntered));
        this.groundCollisionCheck.Connect("body_entered", this, nameof(this.OnGroundCollisionCheckBodyEntered));
        this.jumpTimer.Connect("timeout", this, nameof(this.OnJumpTimerTimeout));
        this.jumpTimer.WaitTime = this.maxJumpTime;
        this.jumpTimer.Start();

        this.player.linearVelocity.y = 5000;
    }

    public override void _StatePhysicsProcess(float delta)
    {
        if (Input.IsActionPressed("jump") && this.onJumpPad)
        {
            this.jumping = true;
            this.jumpTimer.Start();
        }

        if (this.jumping)
        {
            this.player.linearVelocity.y -= this.jumpForce;
        }

        if (this.right)
            this.player.linearVelocity.x = this.movementSpeed;
        else
            this.player.linearVelocity.x = -this.movementSpeed;
        
        if (this.player.linearVelocity.y > this.topFallSpeed)
            this.player.linearVelocity.y = this.topFallSpeed;

        if (this.player.linearVelocity.y < -this.jumpForce)
            this.player.linearVelocity.y = -this.jumpForce;
    }

    public void OnJumpTimerTimeout()
    {
        this.jumping = false;
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
        if (area.IsInGroup("jump"))
        {
            this.onJumpPad = true;
        }

        if (area.IsInGroup("jump_auto"))
        {
            this.jumping = true;
            this.jumpTimer.Start();
        }
    }

    public void OnJumpObjectCollisionCheckAreaExited(Area2D area)
    {
        if (area.IsInGroup("jump"))
        {
            this.onJumpPad = false;
        }
    }

    public void OnGroundCollisionCheckBodyEntered(Node body)
    {
        if (!this.jumping)
        {
            this.player.ChangeState(PlayerStates.RUNNING);
        }
    }

    public override string GetState()
    {
        return "Jumping";
    }
}