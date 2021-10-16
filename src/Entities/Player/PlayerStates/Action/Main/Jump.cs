using Godot;
using System;

public class Jump: MainAction {
    public override void _Init()
    {
        base._Init();

        this.player.jumpForce = 70000;
        this.player.maxJumpTime = 0.04f;
        this.player.maxFallSpeed = 70000;
        this.player.gravity = 10000;
    }
    public override void _ActionProcess(float delta)
    {
        this.player.linearVelocity.y -= this.player.jumpForce;
    }
}