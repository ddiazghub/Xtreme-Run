using Godot;
using System;

public class Jump: MainAction {
    public override void _Init()
    {
        base._Init();

        this.player.jumpForce = this.player.DEFAULT_JUMPFORCE;
        this.player.maxJumpTime = this.player.DEFAULT_MAX_JUMP_TIME;
        this.player.maxFallSpeed = this.player.DEFAULT_JUMPFORCE;
        this.player.gravity = this.player.DEFAULT_GRAVITY;
    }
    public override void _ActionProcess(float delta)
    {
        this.player.linearVelocity.y -= this.player.jumpForce;
    }
}