using Godot;
using System;

public class Jetpack: MainAction {
    public override void _Init()
    {
        this.player.gravity = 10000;
        this.player.jumpForce = 13500;
        this.player.maxJumpTime = 1f;
        this.player.maxFallSpeed = 50000;
    
        base._Init();
    }

    public override void _ActionReleased()
    {
        base._ActionReleased();

        this.performingAction = false;
    }
    public override void _ActionProcess(float delta)
    {
        this.player.linearVelocity.y -= this.player.jumpForce;
    }
}