using Godot;
using System;

public class JumpingState: PlayerState {
    private bool onJumpPad = false;
    public bool jumping = true;
    public bool canJump = false;


    public override void _Init()
    {
        this.player.jumpObjectCollisionCheck.Connect("area_entered", this, nameof(this.OnJumpObjectCollisionCheckAreaEntered));
        this.player.jumpObjectCollisionCheck.Connect("area_exited", this, nameof(this.OnJumpObjectCollisionCheckAreaExited));
        this.player.frontCollisionCheck.Connect("body_entered", this, nameof(this.OnFrontCollisionCheckBodyEntered));
        this.player.groundCollisionCheck.Connect("body_entered", this, nameof(this.OnGroundCollisionCheckBodyEntered));

        this.player.SetHitbox(PersistentState.ON_AIR);
        
        this.player.jumpTimer.Connect("timeout", this, nameof(this.OnJumpTimerTimeout));
        this.player.jumpTimer.WaitTime = this.player.maxJumpTime;
        this.player.jumpTimer.Start();
    }

    public override void _StatePhysicsProcess(float delta)
    {
        if (Input.IsActionJustReleased("action_main")) {
            this.canJump = true;
        }

        if (Input.IsActionPressed("action_main") && this.onJumpPad && this.canJump)
        {
            this.onJumpPad = false;
            this.jumping = true;
            this.player.jumpTimer.Start();
            this.canJump = false;
        }

        if (Input.IsActionPressed("action_secondary"))
        {
            this.jumping = false;
            this.player.linearVelocity.y = 100000;
        }


        if (this.jumping)
        {
            this.player.linearVelocity.y -= this.player.jumpForce;
        }
    }

    public void OnJumpTimerTimeout()
    {
        this.jumping = false;
    }

    public void OnFrontCollisionCheckBodyEntered(Node body)
    {
        if (body.IsInGroup("solid") || body.IsInGroup("hazard"))
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
            this.player.jumpTimer.Start();
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
        if (body.IsInGroup("hazard")) {
            this.player.EmitSignal("Dead");
        }

        if (!this.jumping)
        {
            this.player.ChangePersistentState(PersistentState.ON_GROUND);
        }
    }
}