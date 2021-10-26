using Godot;
using System;

public class OnGroundState: PersistentState {


    public override void _Init()
    {
        base._Init();
        this.player.animation.Play("running");

        this.player.linearVelocity.y = 0;

        this.player.SetHitbox(PlayerPersistentState.ON_GROUND);
    }

    public override void _StatePhysicsProcess(float delta)
    {
        base._StatePhysicsProcess(delta);
        
        if (!this.player.IsOnFloor())
        {
            this.player.ChangePersistentState(PlayerPersistentState.ON_AIR);
        }
    }
}