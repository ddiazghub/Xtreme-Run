using Godot;
using System;

/// <summary>
///     Secondary action that allows the player to fall faster and dodge obstacles by rolling.
/// </summary>
public class FastFallAndRoll: SecondaryAction {
    public override void _ActionOnGround()
    {
        this.Player.mainAction.Blocked = true;
        this.Player.animation.Play("sliding");
        this.Player.SetHitbox(PlayerPersistentState.SECONDARY_ACTION);
        this.Player.secondaryActionTimer.WaitTime = 0.6f;
        base._ActionOnGround();
    }

    public override void _ActionOnAir()
    {
        this.Player.MaxFallSpeed = 1.5f * this.Player.DEFAULT_JUMPFORCE;

        if (this.Player.InvertedGravity)
            this.Player.linearVelocity.y = -1.5f * this.Player.DEFAULT_JUMPFORCE;
        else
            this.Player.linearVelocity.y = 1.5f * this.Player.DEFAULT_JUMPFORCE;
        this.Player.secondaryActionTimer.WaitTime = 0.1f;
        this.Player.secondaryActionTimer.Start();
    }

    public override void OnSecondaryActionTimerTimeout()
    {
        base.OnSecondaryActionTimerTimeout();

        this.Player.MaxFallSpeed = this.Player.DEFAULT_JUMPFORCE;
        this.Player.SetHitbox(PlayerPersistentState.ON_GROUND);
    }
}