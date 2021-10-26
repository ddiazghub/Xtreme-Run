using Godot;
using System;

public class Jump: MainAction {
    public override void _Init()
    {
        this.player.jumpForce = this.player.DEFAULT_JUMPFORCE;
        this.player.maxJumpTime = this.player.DEFAULT_MAX_JUMP_TIME;
        this.player.maxFallSpeed = this.player.DEFAULT_JUMPFORCE;
        this.player.gravity = this.player.DEFAULT_GRAVITY;

        base._Init();
    }
    
    public override void _ActionProcess(float delta)
    {
        GD.Print("Jumping");
        this.player.linearVelocity.y -= this.player.jumpForce;
    }
}