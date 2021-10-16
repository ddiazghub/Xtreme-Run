using Godot;
using System;

public class SwitchGravity: SecondaryAction {
    public override void _Init()
    {
        base._Init();
        this.player.secondaryActionTimer.WaitTime = 0.5f;
    }

    public override void _ActionOnGround()
    {
        this.player.linearVelocity.y -= 2 * this.player.gravity;
        this.invertGravity();
    }

    public override void _ActionOnAir()
    {
        this.invertGravity();
    }

    public override void _ActionReleased()
    {
        base._ActionReleased();
    }
    public override void OnSecondaryActionTimerTimeout()
    {
        if (this.player.invertedGravity)
            this.player.gravity = -10000;
        else
            this.player.gravity = 10000;

        this.player.secondaryActionTimer.Stop();
    }

    public void invertGravity()
    {
        this.player.invertGravity();
        this.player.secondaryActionTimer.Start();

        if (this.player.invertedGravity)
            this.player.gravity = -8000;
        else
            this.player.gravity = 8000;

        this.blocked = true;
    }
}