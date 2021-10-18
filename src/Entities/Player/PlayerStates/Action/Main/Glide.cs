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
        this.player.jumpForce = this.player.DEFAULT_JUMPFORCE;
        this.player.maxJumpTime = this.player.DEFAULT_MAX_JUMP_TIME;
        this.player.maxFallSpeed = this.player.DEFAULT_JUMPFORCE;
        this.player.gravity = this.player.DEFAULT_GRAVITY;

        base._Init();
    }

    public override void _StatePhysicsProcess(float delta)
    {
        if (Input.IsActionJustReleased("action_main")) {

            this._ActionReleased();
        }

        if (Input.IsActionJustPressed("action_secondary"))
        {
            if (this.player.invertedGravity)
                    this.player.gravity = -this.player.DEFAULT_GRAVITY;
                else
                    this.player.gravity = this.player.DEFAULT_GRAVITY;
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
        this.player.mainActionTimer.Start();
        this.canUseActionPad = false;
    }
    public override void _ActionOnAir()
    {
        if (this.onActionPad && this.canUseActionPad) {
            if (this.state == GlideStates.GLIDING)
                this.player.mainActionTimer.WaitTime = this.player.maxJumpTime;

            this.state = GlideStates.JUMPING;
            this.onActionPad = false;
            this.player.mainActionTimer.Start();
            this.canUseActionPad = false;
        }

        if (this.state == GlideStates.CAN_GLIDE)
        {
            this.state = GlideStates.GLIDING;
            this.player.gravity = 0;
            this.player.mainActionTimer.WaitTime = 1f;
            this.player.mainActionTimer.Start();
        }

        if (this.onActionPad && this.canUseActionPad) {
            this.state = GlideStates.JUMPING;
            this.onActionPad = false;
            this.player.mainActionTimer.Start();
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
                if (this.player.invertedGravity)
                    this.player.gravity = -this.player.DEFAULT_GRAVITY;
                else
                    this.player.gravity = this.player.DEFAULT_GRAVITY;

                this.state = GlideStates.NOTHING2;
                this.player.mainActionTimer.WaitTime = this.player.maxJumpTime;
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

    public override void OnMainActionTimerTimeout()
    {
        switch (this.state)
        {
            case GlideStates.JUMPING:
                this.state = GlideStates.NOTHING;
                break;
            
            case GlideStates.GLIDING:
                if (this.player.invertedGravity)
                    this.player.gravity = -this.player.DEFAULT_GRAVITY;
                else
                    this.player.gravity = this.player.DEFAULT_GRAVITY;

                this.state = GlideStates.NOTHING2;
                this.player.mainActionTimer.WaitTime = this.player.maxJumpTime;
                break;
        }
    }

    public override void OnMainActionObjectCollisionCheckAreaEntered(Area2D area)
    {
        if (area.IsInGroup("jump"))
        {
            this.onActionPad = true;
        }

        if (area.IsInGroup("jump_auto"))
        {
            if (this.state == GlideStates.GLIDING)
                this.player.mainActionTimer.WaitTime = this.player.maxJumpTime;

            this.state = GlideStates.JUMPING;
            this.player.mainActionTimer.Start();
        }
    }
}