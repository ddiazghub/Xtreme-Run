using Godot;
using System;

public class SwitchGravity: SecondaryAction {
    public override void _Init()
    {
        base._Init();
        this.player.secondaryActionTimer.WaitTime = 0.3f;
    }

    public override void _StatePhysicsProcess(float delta)
    {
        base._StatePhysicsProcess(delta);
    }
    public override void _ActionOnGround()
    {
        this.player.linearVelocity.y = -2 * this.player.gravity;
        this.invertGravity();
        base._ActionOnGround();
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
            this.player.gravity = -this.player.DEFAULT_GRAVITY;
        else
            this.player.gravity = this.player.DEFAULT_GRAVITY;

        this.player.secondaryActionTimer.Stop();
    }

    public void invertGravity()
    {
        this.player.invertGravity();
        this.player.secondaryActionTimer.Start();

        if (this.player.invertedGravity)
            this.player.gravity = -this.player.DEFAULT_GRAVITY + 50;
        else
            this.player.gravity = this.player.DEFAULT_GRAVITY - 50;

        this.blocked = true;
    }
}