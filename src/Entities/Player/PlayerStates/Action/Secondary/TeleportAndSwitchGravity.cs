using Godot;
using System;

public class TeleportAndSwitchGravity: SecondaryAction {
    public override void _Init()
    {
        base._Init();
        this.player.secondaryActionTimer.WaitTime = 0.04f;
    }

    public override void _ActionOnGround()
    {
        this.player.maxFallSpeed = 8333;
        this.player.Visible = false;
        this.player.linearVelocity.y -= 1000 * this.player.gravity;
        this.player.secondaryActionTimer.Start();
        this.player.invincible = true;
        this.invertGravity();
        base._ActionOnGround();
    }

    public override void _ActionOnAir()
    {

    }

    public override void _ActionReleased()
    {
        base._ActionReleased();
    }

    public override void OnSecondaryActionTimerTimeout()
    {
        this.player.maxFallSpeed = this.player.DEFAULT_JUMPFORCE;
        this.player.linearVelocity.y = 0;
        this.player.Visible = true;
        this.player.invincible = false;
        this.player.secondaryActionTimer.Stop();
    }

    public void invertGravity()
    {
        this.player.invertGravity();
        this.player.secondaryActionTimer.Start();

        this.blocked = true;
    }
}