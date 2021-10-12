using Godot;
using System;

public class Jump: MainAction {
    public override void _ActionProcess(float delta)
    {
        this.player.linearVelocity.y -= this.player.jumpForce;
    }
}