using Godot;
using System;

/// <summary>
///     Persistent state when the player is grounded.
/// </summary>
public class OnGroundState: PersistentState {


    public override void _Init()
    {
        base._Init();
        this.Player.animation.Play("running");

        this.Player.linearVelocity.y = 0;

        this.Player.SetHitbox(PlayerPersistentState.ON_GROUND);
    }

    public override void _StatePhysicsProcess(float delta)
    {
        base._StatePhysicsProcess(delta);
        
        if (!this.Player.IsOnFloor())
        {
            this.Player.ChangePersistentState(PlayerPersistentState.ON_AIR);
        }
    }
}