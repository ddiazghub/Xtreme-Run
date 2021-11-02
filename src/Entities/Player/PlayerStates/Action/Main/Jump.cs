using Godot;
using System;

/// <summary>
///     Main action that allows the player to jump.
/// </summary>
public class Jump: MainAction {
    public override void _Init()
    {
        this.Player.JumpForce = this.Player.DEFAULT_JUMPFORCE;
        this.Player.MaxJumpTime = this.Player.DEFAULT_MAX_JUMP_TIME;
        this.Player.MaxFallSpeed = this.Player.DEFAULT_JUMPFORCE;
        this.Player.Gravity = this.Player.DEFAULT_GRAVITY;

        base._Init();
    }
    
    public override void _ActionProcess(float delta)
    {
        this.Player.linearVelocity.y -= this.Player.JumpForce;
    }
}