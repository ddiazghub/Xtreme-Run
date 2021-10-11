using Godot;
using System;

public class SecondaryActionState: PlayerState {


    public override void _Init()
    {
        this.animation.Play("sliding");
        
        this.frontCollisionCheck.Connect("body_entered", this, nameof(this.OnFrontCollisionCheckBodyEntered));
        this.jumpObjectCollisionCheck.Connect("area_entered", this, nameof(this.OnJumpObjectCollisionCheckAreaEntered));

        this.SetHitbox(PlayerPersistentState.SECONDARY_ACTION);

        this.slideTimer.Connect("timeout", this, nameof(this.OnSlideTimerTimeout));
        this.slideTimer.Start();
    }

    public override void _StatePhysicsProcess(float delta)
    {
        if (this.right)
            this.player.linearVelocity.x = this.movementSpeed;
        else
            this.player.linearVelocity.x = -this.movementSpeed;
    }

    public void OnFrontCollisionCheckBodyEntered(Node body)
    {
        if (body.IsInGroup("solid") || body.IsInGroup("hazard"))
        {
            this.player.EmitSignal("Dead");
        }
    }

    public void OnJumpObjectCollisionCheckAreaEntered(Area2D area)
    {
        /*
        if (area.IsInGroup("jump"))
        {
            this._onJumpObject = true;
        }
        */

        if (area.IsInGroup("jump_auto"))
        {
            this.player.ChangePersistentState(PlayerPersistentState.ON_AIR);
        }
    }

    public void OnSlideTimerTimeout()
    {
        if (this.player.IsOnFloor())
            this.player.ChangePersistentState(PlayerPersistentState.ON_GROUND);
        else
            this.player.ChangePersistentState(PlayerPersistentState.ON_AIR);
    }

    public override string GetState()
    {
        return "Sliding";
    }
}