using Godot;
using System;

/// <summary>
///     Secondary action that allows the player to teleport and invert the direction of gravity.
/// </summary>
public class TeleportAndSwitchGravity: SecondaryAction {
    public override void _Init()
    {
        base._Init();
        this.Player.secondaryActionTimer.WaitTime = 0.04f;
    }

    public override void _ActionOnGround()
    {
        this.Player.MaxFallSpeed = 8333;
        this.Player.Visible = false;
        this.Player.linearVelocity.y -= 1000 * this.Player.Gravity;
        this.Player.secondaryActionTimer.Start();
        this.Player.Invincible = true;
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
        this.Player.MaxFallSpeed = this.Player.DEFAULT_JUMPFORCE;
        this.Player.linearVelocity.y = 0;
        this.Player.Visible = true;
        this.Player.Invincible = false;
        this.Player.secondaryActionTimer.Stop();
    }

    /// <summary>
    ///     Invert's the player's gravity.
    /// </summary>
    public void invertGravity()
    {
        this.Player.InvertGravity();
        this.Player.secondaryActionTimer.Start();

        this.Blocked = true;
    }
}