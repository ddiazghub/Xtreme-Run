using Godot;
using System;

public class OnAirState: PersistentState {


    public override void _Init()
    {
        base._Init();
        this.player.animation.Play("running");
        this.player.SetHitbox(PlayerPersistentState.ON_AIR);
    }

    public override void _StatePhysicsProcess(float delta)
    {
        base._StatePhysicsProcess(delta);

        if (this.player.IsOnFloor())
        {
            this.player.ChangePersistentState(PlayerPersistentState.ON_GROUND);
        }

        if (this.player.linearVelocity.y > -this.player.DEFAULT_GRAVITY && this.player.linearVelocity.y < this.player.DEFAULT_GRAVITY)
            this.player.linearVelocity.y += this.player.gravity / 5;
        else
            this.player.linearVelocity.y += this.player.gravity;

        if (this.player.invertedGravity)
        {
            if (this.player.linearVelocity.y > this.player.jumpForce)
                this.player.linearVelocity.y = this.player.jumpForce;

            if (this.player.linearVelocity.y < -this.player.maxFallSpeed)
                this.player.linearVelocity.y = -this.player.maxFallSpeed;
        }
        else
        {
            if (this.player.linearVelocity.y > this.player.maxFallSpeed)
                this.player.linearVelocity.y = this.player.maxFallSpeed;

            if (this.player.linearVelocity.y < -this.player.jumpForce)
                this.player.linearVelocity.y = -this.player.jumpForce;
        }
    }
}