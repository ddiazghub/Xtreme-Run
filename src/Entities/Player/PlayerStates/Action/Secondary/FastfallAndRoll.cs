using Godot;
using System;

public class FastFallAndRoll: SecondaryAction {
    public override void _ActionOnGround()
    {
        this.player.animation.Play("sliding");
        this.player.SetHitbox(PlayerPersistentState.SECONDARY_ACTION);
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