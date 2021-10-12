using Godot;
using System;

public class Jump: PlayerState {
    private bool onJumpPad = false;
    public bool jumping = false;
    public bool canUseJumpPad = true;
    private bool blocked = false;

    public override void _Init()
    {
        this.player.jumpObjectCollisionCheck.Connect("area_entered", this, nameof(this.OnJumpObjectCollisionCheckAreaEntered));
        this.player.jumpObjectCollisionCheck.Connect("area_exited", this, nameof(this.OnJumpObjectCollisionCheckAreaExited));
        
        this.player.jumpTimer.Connect("timeout", this, nameof(this.OnJumpTimerTimeout));
        this.player.jumpTimer.WaitTime = this.player.maxJumpTime;
        this.player.jumpTimer.Start();
    }

    public override void _StatePhysicsProcess(float delta)
    {
        if (Input.IsActionJustReleased("action_main")) {
            this.canUseJumpPad = true;
        }

        if (Input.IsActionPressed("action_main") && !this.blocked) {
            if (this.player.persistentState is OnGroundState) {
                this.jumping = true;
                this.player.jumpTimer.Start();
                this.canUseJumpPad = false;
            }

            if (this.player.persistentState is OnAirState) {
                if (this.onJumpPad && this.canUseJumpPad) {
                    this.jumping = true;
                    this.onJumpPad = false;
                    this.player.jumpTimer.Start();
                    this.canUseJumpPad = false;
                }
            }
        }

        if (this.jumping)
        {
            this.player.linearVelocity.y -= this.player.jumpForce;
        }
    }

    public override void Block()
    {
        this.blocked = true;
    }

    public override void UnBlock()
    {
        this.blocked = false;
    }

    public void OnJumpTimerTimeout()
    {
        this.jumping = false;
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
}