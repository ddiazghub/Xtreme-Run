using Godot;
using System;

public class Jetpack: MainAction {
    private readonly int JETPACK_JUMPFORCE = 350;
    private readonly float JETPACK_MAX_JUMP_TIME = 0.4f;
    private readonly int JETPACK_MAX_FALL_SPEED = 900;
    private bool onAutoJump = false;

    public override void _Init()
    {
        this.player.gravity = this.player.DEFAULT_GRAVITY;
        this.player.jumpForce = this.JETPACK_JUMPFORCE;
            this.player.maxJumpTime = this.JETPACK_MAX_JUMP_TIME;
            this.player.maxFallSpeed = this.JETPACK_MAX_FALL_SPEED;
    
        base._Init();
    }

    public override void _ActionReleased()
    {
        base._ActionReleased();

        if (!this.onAutoJump)
            this.performingAction = false;
    }

    public override void _ActionProcess(float delta)
    {
        this.player.linearVelocity.y -= this.player.jumpForce;
    }

    public override void OnMainActionObjectCollisionCheckAreaEntered(Area2D area)
    {
        if (area.IsInGroup("jump_auto"))
        {
            this.player.jumpForce = this.player.DEFAULT_JUMPFORCE;
            this.player.mainActionTimer.WaitTime = this.player.DEFAULT_MAX_JUMP_TIME;
            this.player.maxFallSpeed = this.player.DEFAULT_JUMPFORCE;
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
            this.player.jumpForce = this.JETPACK_JUMPFORCE;
            this.player.maxJumpTime = this.JETPACK_MAX_JUMP_TIME;
            this.player.maxFallSpeed = this.JETPACK_MAX_FALL_SPEED;
        }
    }
}