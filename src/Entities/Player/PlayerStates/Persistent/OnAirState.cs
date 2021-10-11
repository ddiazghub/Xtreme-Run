using Godot;
using System;

public class OnAirState: PlayerState {


    public override void _Init()
    {
        this.player.animation.Play("running");
        
        this.player.frontCollisionCheck.Connect("body_entered", this, nameof(this.OnFrontCollisionCheckBodyEntered));
        this.player.jumpObjectCollisionCheck.Connect("area_entered", this, nameof(this.OnJumpObjectCollisionCheckAreaEntered));
        this.player.groundCollisionCheck.Connect("body_exited", this, nameof(this.OnGroundCollisionCheckBodyExited));

        this.player.SetHitbox(PersistentState.ON_GROUND);
    }

    public override void _StatePhysicsProcess(float delta)
    {
        if (Input.IsActionPressed("action_main"))
        {
            this.player.ChangePersistentState(PersistentState.ON_AIR);
        }

        if (Input.IsActionPressed("action_secondary"))
        {
            this.player.ChangePersistentState(PersistentState.SECONDARY_ACTION);
        }


        if (this.player.right)
            this.player.linearVelocity.x = this.player.movementSpeed;
        else
            this.player.linearVelocity.x = -this.player.movementSpeed;

        if (this.player.linearVelocity.y > this.player.topFallSpeed)
            this.player.linearVelocity.y = this.player.topFallSpeed;

        if (this.player.linearVelocity.y < -this.player.jumpForce)
            this.player.linearVelocity.y = -this.player.jumpForce;
            
        if (this.player.linearVelocity.y > -10000 && this.player.linearVelocity.y < 10000)
            this.player.linearVelocity.y += this.player.gravity / 5;
        else
            this.player.linearVelocity.y += this.player.gravity;
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
            this.player.ChangePersistentState(PersistentState.ON_AIR);
        }
    }

    public void OnGroundCollisionCheckBodyExited(Node body)
    {
        if (body.IsInGroup("solid")) 
        {
            this.player.ChangePersistentState(PersistentState.ON_AIR);
        }
    }
}