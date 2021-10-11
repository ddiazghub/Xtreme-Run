using Godot;
using System;

public abstract class PersistentState: PlayerState {


    public override void _Init()
    {
        this.player.frontCollisionCheck.Connect("body_entered", this, nameof(this.OnFrontCollisionCheckBodyEntered));
        this.player.groundCollisionCheck.Connect("body_entered", this, nameof(this.OnGroundCollisionCheckBodyEntered));
        this.player.groundCollisionCheck.Connect("body_exited", this, nameof(this.OnGroundCollisionCheckBodyExited));
    }

    public override void _StatePhysicsProcess(float delta)
    {
        if (this.player.right)
            this.player.linearVelocity.x = this.player.movementSpeed;
        else
            this.player.linearVelocity.x = -this.player.movementSpeed;
    }

    public void OnFrontCollisionCheckBodyEntered(Node body)
    {
        if (body.IsInGroup("solid") || body.IsInGroup("hazard"))
        {
            this.player.EmitSignal("Dead");
        }
    }

    public virtual void OnGroundCollisionCheckBodyEntered(Node body)
    {
        if (body.IsInGroup("hazard")) {
            this.player.EmitSignal("Dead");
        }
    }

    public abstract void OnGroundCollisionCheckBodyExited(Node body);
}