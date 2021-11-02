using Godot;
using System;

/// <summary>
///     Secondary action that allows the player to invert the direction of gravity.
/// </summary>
public class SwitchGravity: SecondaryAction {
    public override void _Init()
    {
        base._Init();
        this.Player.secondaryActionTimer.WaitTime = 0.3f;
    }

    public override void _StatePhysicsProcess(float delta)
    {
        base._StatePhysicsProcess(delta);
    }
    public override void _ActionOnGround()
    {
        this.Player.linearVelocity.y = -2 * this.Player.Gravity;
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
        if (this.Player.InvertedGravity)
            this.Player.Gravity = -this.Player.DEFAULT_GRAVITY;
        else
            this.Player.Gravity = this.Player.DEFAULT_GRAVITY;

        this.Player.secondaryActionTimer.Stop();
    }

    /// <summary>
    ///     Invert's the player's gravity.
    /// </summary>
    public void invertGravity()
    {
        this.Player.InvertGravity();
        this.Player.secondaryActionTimer.Start();

        if (this.Player.InvertedGravity)
            this.Player.Gravity = -this.Player.DEFAULT_GRAVITY + 50;
        else
            this.Player.Gravity = this.Player.DEFAULT_GRAVITY - 50;

        this.Blocked = true;
    }
}