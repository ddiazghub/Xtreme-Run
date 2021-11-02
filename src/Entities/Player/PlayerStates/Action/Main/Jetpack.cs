using Godot;
using System;

/// <summary>
///     Main action that allows the player to control to fly in a jetpack.
///     This allows them to jump higher and have better control of their jump.
/// </summary>
public class Jetpack: MainAction {
    // Jetpack action constants.
    private readonly int JETPACK_JUMPFORCE = 350;
    private readonly float JETPACK_MAX_JUMP_TIME = 0.4f;
    private readonly int JETPACK_MAX_FALL_SPEED = 900;

    /// <summary>
    ///     True if the player has touched a jump pad.
    /// </summary>
    private bool onAutoJump = false;

    public override void _Init()
    {
        this.Player.Gravity = this.Player.DEFAULT_GRAVITY;
        this.Player.JumpForce = this.JETPACK_JUMPFORCE;
        this.Player.MaxJumpTime = this.JETPACK_MAX_JUMP_TIME;
        this.Player.MaxFallSpeed = this.JETPACK_MAX_FALL_SPEED;
    
        base._Init();
    }

    public override void _ActionReleased()
    {
        base._ActionReleased();

        if (!this.onAutoJump)
            this.PerformingAction = false;
    }

    public override void _ActionProcess(float delta)
    {
        this.Player.linearVelocity.y -= this.Player.JumpForce;
    }

    public override void OnMainActionObjectCollisionCheckAreaEntered(Area2D area)
    {
        if (area.IsInGroup("jump_auto"))
        {
            this.Player.JumpForce = this.Player.DEFAULT_JUMPFORCE;
            this.Player.mainActionTimer.WaitTime = this.Player.DEFAULT_MAX_JUMP_TIME;
            this.Player.MaxFallSpeed = this.Player.DEFAULT_JUMPFORCE;
            this.onAutoJump = true;
        }

        base.OnMainActionObjectCollisionCheckAreaEntered(area);
    }

    public override void OnMainActionTimerTimeout()
    {
        base.OnMainActionTimerTimeout();

        if (this.onAutoJump)
        {
            this.onAutoJump = false;
            this.Player.JumpForce = this.JETPACK_JUMPFORCE;
            this.Player.MaxJumpTime = this.JETPACK_MAX_JUMP_TIME;
            this.Player.MaxFallSpeed = this.JETPACK_MAX_FALL_SPEED;
        }
    }
}