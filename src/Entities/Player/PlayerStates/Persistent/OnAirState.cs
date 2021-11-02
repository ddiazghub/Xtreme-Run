using Godot;
using System;

/// <summary>
///     Persisten state when the player is on air.
/// </summary>
public class OnAirState: PersistentState {


    public override void _Init()
    {
        base._Init();
        this.Player.animation.Play("running");
        this.Player.SetHitbox(PlayerPersistentState.ON_AIR);
    }

    public override void _StatePhysicsProcess(float delta)
    {
        base._StatePhysicsProcess(delta);

        if (this.Player.IsOnFloor())
        {
            this.Player.ChangePersistentState(PlayerPersistentState.ON_GROUND);
        }

        if (Math.Abs(this.Player.linearVelocity.y) < this.Player.DEFAULT_GRAVITY)
            this.Player.linearVelocity.y += this.Player.Gravity / 5;
        else
            this.Player.linearVelocity.y += this.Player.Gravity;

        if (this.Player.InvertedGravity)
        {
            if (this.Player.linearVelocity.y > -this.Player.JumpForce)
                this.Player.linearVelocity.y = -this.Player.JumpForce;

            if (this.Player.linearVelocity.y < -this.Player.MaxFallSpeed)
                this.Player.linearVelocity.y = -this.Player.MaxFallSpeed;
        }
        else
        {
            if (this.Player.linearVelocity.y > this.Player.MaxFallSpeed)
                this.Player.linearVelocity.y = this.Player.MaxFallSpeed;

            if (this.Player.linearVelocity.y < -this.Player.JumpForce)
                this.Player.linearVelocity.y = -this.Player.JumpForce;
        }
    }
}