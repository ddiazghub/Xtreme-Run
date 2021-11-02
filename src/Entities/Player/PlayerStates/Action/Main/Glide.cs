using Godot;
using System;

/// <summary>
///     Main action that allows the player to glide for some time.
/// </summary> 
public class Glide: MainAction {

    /// <summary>
    ///     Each state that the glide action can have.
    /// </summary>
    private enum GlideStates {
        JUMPING,
        NOTHING,
        CAN_GLIDE,
        GLIDING,
        NOTHING2
    }

    /// <summary>
    ///     The state in which the glide action is currently.
    /// </summary>
    private GlideStates state = GlideStates.NOTHING;

    public override void _Init()
    {
        this.Player.JumpForce = this.Player.DEFAULT_JUMPFORCE;
        this.Player.MaxJumpTime = this.Player.DEFAULT_MAX_JUMP_TIME;
        this.Player.MaxFallSpeed = this.Player.DEFAULT_JUMPFORCE;
        this.Player.Gravity = this.Player.DEFAULT_GRAVITY;

        base._Init();
    }

    public override void _StatePhysicsProcess(float delta)
    {
        if (Input.IsActionJustReleased("action_main")) {

            this._ActionReleased();
        }

        if (Input.IsActionJustPressed("action_secondary"))
        {
            if (this.Player.InvertedGravity)
                    this.Player.Gravity = -this.Player.DEFAULT_GRAVITY;
                else
                    this.Player.Gravity = this.Player.DEFAULT_GRAVITY;
        }

        if (Input.IsActionPressed("action_main") && (this.state == GlideStates.NOTHING || this.state == GlideStates.CAN_GLIDE) && !this.Player.Blocked) {
            if (this.Player.persistentState is OnGroundState) {
                this._ActionOnGround();
            }

            if (this.Player.persistentState is OnAirState) {
                this._ActionOnAir();
            }
        }

        if (this.state == GlideStates.GLIDING || this.state == GlideStates.JUMPING)
        {
            this._ActionProcess(delta);
        }

        if (this.Player.IsOnFloor())
            this.state = GlideStates.NOTHING;
    }

    public override void _ActionOnGround()
    {
        this.state = GlideStates.JUMPING;
        this.Player.mainActionTimer.Start();
        this.CanUseActionPad = false;
    }
    public override void _ActionOnAir()
    {
        if (this.OnActionPad && this.CanUseActionPad) {
            if (this.state == GlideStates.GLIDING)
                this.Player.mainActionTimer.WaitTime = this.Player.MaxJumpTime;

            this.state = GlideStates.JUMPING;
            this.OnActionPad = false;
            this.Player.mainActionTimer.Start();
            this.CanUseActionPad = false;
        }

        if (this.state == GlideStates.CAN_GLIDE)
        {
            this.state = GlideStates.GLIDING;
            this.Player.Gravity = 0;
            this.Player.mainActionTimer.WaitTime = 1f;
            this.Player.mainActionTimer.Start();
        }

        if (this.OnActionPad && this.CanUseActionPad) {
            this.state = GlideStates.JUMPING;
            this.OnActionPad = false;
            this.Player.mainActionTimer.Start();
            this.CanUseActionPad = false;
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
                if (this.Player.InvertedGravity)
                    this.Player.Gravity = -this.Player.DEFAULT_GRAVITY;
                else
                    this.Player.Gravity = this.Player.DEFAULT_GRAVITY;

                this.state = GlideStates.NOTHING2;
                this.Player.mainActionTimer.WaitTime = this.Player.MaxJumpTime;
                break;
        }
    }
    public override void _ActionProcess(float delta)
    {
        switch (this.state)
        {
            case GlideStates.JUMPING:
                this.Player.linearVelocity.y -= this.Player.JumpForce;
                break;
            
            case GlideStates.GLIDING:
                this.Player.linearVelocity.y = 0;
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
                if (this.Player.InvertedGravity)
                    this.Player.Gravity = -this.Player.DEFAULT_GRAVITY;
                else
                    this.Player.Gravity = this.Player.DEFAULT_GRAVITY;

                this.state = GlideStates.NOTHING2;
                this.Player.mainActionTimer.WaitTime = this.Player.MaxJumpTime;
                break;
        }
    }

    public override void OnMainActionObjectCollisionCheckAreaEntered(Area2D area)
    {
        if (area.IsInGroup("jump"))
        {
            this.OnActionPad = true;
        }

        if (area.IsInGroup("jump_auto"))
        {
            if (this.state == GlideStates.GLIDING)
                this.Player.mainActionTimer.WaitTime = this.Player.MaxJumpTime;

            this.state = GlideStates.JUMPING;
            this.Player.mainActionTimer.Start();
        }
    }
}