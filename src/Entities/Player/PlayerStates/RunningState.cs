using Godot;
using System;

public class RunningState: PlayerState {


    public override void _Init()
    {
        this.animation.Play("running");
        
        this.frontCollisionCheck.Connect("body_entered", this, nameof(this.OnFrontCollisionCheckBodyEntered));
        this.jumpObjectCollisionCheck.Connect("area_entered", this, nameof(this.OnJumpObjectCollisionCheckAreaEntered));
        this.groundCollisionCheck.Connect("body_exited", this, nameof(this.OnGroundCollisionCheckBodyExited));

        this.SetHitbox(State.RUNNING);
    }

    public override void _StatePhysicsProcess(float delta)
    {
        if (Input.IsActionPressed("action_main"))
        {
            this.player.ChangeState(State.MAIN_ACTION);
        }

        if (Input.IsActionPressed("action_secondary"))
        {
            this.player.ChangeState(State.SECONDARY_ACTION);
        }


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
            this.player.ChangeState(State.MAIN_ACTION);
        }
    }

    public void OnGroundCollisionCheckBodyExited(Node body)
    {
        if (body.IsInGroup("solid")) 
        {
            this.player.ChangeState(State.FALLING);
        }
    }

    public override string GetState()
    {
        return "Running";
    }
}