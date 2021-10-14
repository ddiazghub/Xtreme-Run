using Godot;
using System;

public abstract class PersistentState: PlayerState {


    public override void _Init()
    {
    }

    public override void _StatePhysicsProcess(float delta)
    {
        if (this.player.IsOnWall() || this.player.IsOnCeiling())
        {
            this.player.EmitSignal("Dead");
        }

        for (int i = 0; i < this.player.GetSlideCount(); i++)
        {
            if (((Node) this.player.GetSlideCollision(i).Collider).IsInGroup("hazard"))
            {
                this.player.EmitSignal("Dead");
            }
        }

        
        if (this.player.right)
            this.player.linearVelocity.x = this.player.movementSpeed;
        else
            this.player.linearVelocity.x = -this.player.movementSpeed;
    }
}