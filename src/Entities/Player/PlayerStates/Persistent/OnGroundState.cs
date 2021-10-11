using Godot;
using System;

public class OnGroundState: PersistentState {


    public override void _Init()
    {
        base._Init();
        this.player.animation.Play("running");

        this.player.linearVelocity.y = 3000;

        this.player.SetHitbox(PlayerPersistentState.ON_GROUND);
    }

    public override void _StatePhysicsProcess(float delta)
    {

    }

    public override void OnGroundCollisionCheckBodyExited(Node body)
    {
        if (body.IsInGroup("solid")) 
        {
            this.player.ChangePersistentState(PlayerPersistentState.ON_AIR);
        }
    }
}