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

        if (this.player.linearVelocity.y > this.player.topFallSpeed)
            this.player.linearVelocity.y = this.player.topFallSpeed;

        if (this.player.linearVelocity.y < -this.player.jumpForce)
            this.player.linearVelocity.y = -this.player.jumpForce;

        if (this.player.linearVelocity.y > -10000 && this.player.linearVelocity.y < 10000)
            this.player.linearVelocity.y += this.player.gravity / 5;
        else
            this.player.linearVelocity.y += this.player.gravity;
    }

    public override void OnGroundCollisionCheckBodyEntered(Node body)
    {
        base.OnGroundCollisionCheckBodyEntered(body);

        if (body.IsInGroup("solid")) {
            this.player.ChangePersistentState(PlayerPersistentState.ON_GROUND);
        }
    }

    public override void OnGroundCollisionCheckBodyExited(Node body) {
        
    }
}