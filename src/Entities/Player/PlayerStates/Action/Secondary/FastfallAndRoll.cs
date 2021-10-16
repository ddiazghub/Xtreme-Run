using Godot;
using System;

public class FastFallAndRoll: SecondaryAction {
    public override void _ActionOnGround()
    {
        this.player.mainAction.Block();
        this.player.animation.Play("sliding");
        this.player.SetHitbox(PlayerPersistentState.SECONDARY_ACTION);
        this.player.secondaryActionTimer.WaitTime = 0.5f;
    }

    public override void _ActionOnAir()
    {
        this.player.linearVelocity.y = 100000;
    }

    public override void OnSecondaryActionTimerTimeout()
    {
        base.OnSecondaryActionTimerTimeout();
    }
}