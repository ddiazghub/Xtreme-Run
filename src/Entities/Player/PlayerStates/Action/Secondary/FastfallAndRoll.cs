using Godot;
using System;

public class FastFallAndRoll: SecondaryAction {
    public override void _ActionOnGround()
    {
        this.player.mainAction.Block();
        this.player.animation.Play("sliding");
        this.player.SetHitbox(PlayerPersistentState.SECONDARY_ACTION);
        this.player.secondaryActionTimer.WaitTime = 0.6f;
        base._ActionOnGround();
    }

    public override void _ActionOnAir()
    {
        this.player.maxFallSpeed = 1.5f * this.player.DEFAULT_JUMPFORCE;
        this.player.linearVelocity.y = 1.5f * this.player.DEFAULT_JUMPFORCE;
        this.player.secondaryActionTimer.WaitTime = 0.1f;
        this.player.secondaryActionTimer.Start();
    }

    public override void OnSecondaryActionTimerTimeout()
    {
        base.OnSecondaryActionTimerTimeout();

        this.player.maxFallSpeed = this.player.DEFAULT_JUMPFORCE;
        this.player.SetHitbox(PlayerPersistentState.ON_GROUND);
    }
}