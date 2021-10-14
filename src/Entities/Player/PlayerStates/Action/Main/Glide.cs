using Godot;
using System;

public class Glide: MainAction {
    private enum GlideStates {
        JUMPING,
        NOTHING,
        CAN_GLIDE,
        GLIDING,
        NOTHING2
    }

    private GlideStates state = GlideStates.NOTHING;

    public override void _Init()
    {
        this.player.jumpForce = 100000;
        this.player.maxJumpTime = 0.04f;
        this.player.maxFallSpeed = 100000;

        base._Init();
    }

    public override void _StatePhysicsProcess(float delta)
    {
        GD.Print(this.state.ToString());
        if (Input.IsActionJustReleased("action_main")) {

            this._ActionReleased();
        }

        if (Input.IsActionJustPressed("action_secondary"))
        {
            this.player.gravity = 10000;
        }

        if (Input.IsActionPressed("action_main") && (this.state == GlideStates.NOTHING || this.state == GlideStates.CAN_GLIDE) && !this.player.blocked) {
            if (this.player.persistentState is OnGroundState) {
                this._ActionOnGround();
            }

            if (this.player.persistentState is OnAirState) {
                this._ActionOnAir();
            }
        }

        if (this.state == GlideStates.GLIDING || this.state == GlideStates.JUMPING)
        {
            this._ActionProcess(delta);
        }

        if (this.player.IsOnFloor())
            this.state = GlideStates.NOTHING;
    }

    public override void _ActionOnGround()
    {
        this.state = GlideStates.JUMPING;
        this.player.jumpTimer.Start();
        this.canUseActionPad = false;
    }
    public override void _ActionOnAir()
    {
        if (this.onActionPad && this.canUseActionPad) {
            if (this.state == GlideStates.GLIDING)
                this.player.jumpTimer.WaitTime = this.player.maxJumpTime;

            this.state = GlideStates.JUMPING;
            this.onActionPad = false;
            this.player.jumpTimer.Start();
            this.canUseActionPad = false;
        }

        if (this.state == GlideStates.CAN_GLIDE)
        {
            this.state = GlideStates.GLIDING;
            this.player.gravity = 0;
            this.player.jumpTimer.WaitTime = 1f;
            this.player.jumpTimer.Start();
        }

        if (this.onActionPad && this.canUseActionPad) {
            this.state = GlideStates.JUMPING;
            this.onActionPad = false;
            this.player.jumpTimer.Start();
            this.canUseActionPad = false;
        }
    }
    public override void _ActionReleased()
    {
        base._ActionReleased();

        switch (this.state)
        {
            case GlideStates.NOTHING:
                this.state = GlideStates.CAN_GLIDE;
                break;
            
            case GlideStates.GLIDING:
                this.player.gravity = 10000;
                this.state = GlideStates.NOTHING2;
                this.player.jumpTimer.WaitTime = this.player.maxJumpTime;
                break;
        }
    }
    public override void _ActionProcess(float delta)
    {
        switch (this.state)
        {
            case GlideStates.JUMPING:
                this.player.linearVelocity.y -= this.player.jumpForce;
                break;
            
            case GlideStates.GLIDING:
                this.player.linearVelocity.y = 0;
                break;
        }
    }

    public override void OnJumpTimerTimeout()
    {
        switch (this.state)
        {
            case GlideStates.JUMPING:
                this.state = GlideStates.NOTHING;
                break;
            
            case GlideStates.GLIDING:
                this.player.gravity = 10000;
                this.state = GlideStates.NOTHING2;
                this.player.jumpTimer.WaitTime = this.player.maxJumpTime;
                break;
        }
    }

    public override void OnJumpObjectCollisionCheckAreaEntered(Area2D area)
    {
        if (area.IsInGroup("jump"))
        {
            this.onActionPad = true;
        }

        if (area.IsInGroup("jump_auto"))
        {
            if (this.state == GlideStates.GLIDING)
                this.player.jumpTimer.WaitTime = this.player.maxJumpTime;

            this.state = GlideStates.JUMPING;
            this.player.jumpTimer.Start();
        }
    }
}