using Godot;
using System;

public class RunningState: PlayerState {


    public override void _Init()
    {
        this.animation.Play("running");
        
        this.frontCollisionCheck.Connect("body_entered", this, nameof(this.OnFrontCollisionCheckBodyEntered));
        this.jumpObjectCollisionCheck.Connect("area_entered", this, nameof(this.OnJumpObjectCollisionCheckAreaEntered));

        this.frontCollisionCheck.GetNode<CollisionShape2D>("RunningCollisionShape").Disabled = false;
        this.frontCollisionCheck.GetNode<CollisionShape2D>("SlidingCollisionShape").Disabled = true;
        this.frontCollisionCheck.GetNode<CollisionShape2D>("JumpingCollisionShape").Disabled = true;
        this.player.GetNode<CollisionShape2D>("RunningCollision").Disabled = false;
        this.player.GetNode<CollisionShape2D>("SlidingCollision").Disabled = true;
    }

    public override void _StatePhysicsProcess(float delta)
    {
        if (Input.IsActionPressed("jump"))
        {
            this.player.ChangeState(PlayerStates.JUMPING);
        }

        if (Input.IsActionPressed("down"))
        {
            this.player.ChangeState(PlayerStates.SLIDING);
        }


        if (this.right)
            this.player.linearVelocity.x = this.movementSpeed;
        else
            this.player.linearVelocity.x = -this.movementSpeed;
    }

    public void OnFrontCollisionCheckBodyEntered(Node body)
    {
        if (body.IsInGroup("solid"))
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
            this.player.ChangeState(PlayerStates.JUMPING);
        }
    }

    public override string GetState()
    {
        return "Running";
    }
}