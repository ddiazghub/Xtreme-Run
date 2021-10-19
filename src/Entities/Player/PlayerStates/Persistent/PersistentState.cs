using Godot;
using System;

public abstract class PersistentState: PlayerState {


    public override void _Init()
    {
        this.player.jumpObjectCollisionCheck.Connect("area_entered", this, nameof(this.OnActionObjectCollisionCheckAreaEntered));
    }

    public override void _StatePhysicsProcess(float delta)
    {
        if (this.player.Position.y > 4000 || this.player.Position.y < -4000)
            this.player.EmitSignal("Dead");

        if (!this.player.invincible)
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
        }

        this.player.linearVelocity.x = this.player.movementSpeed;
    }

    public void OnActionObjectCollisionCheckAreaEntered(Area2D area)
    {
        if (area.IsInGroup("pickup_main"))
        {
            this.player.ChangeMainAction(((MainActionPickup) area).GetPickupType());   
        }

        if (area.IsInGroup("pickup_secondary"))
        {
            this.player.ChangeSecondaryAction(((SecondaryActionPickup) area).GetPickupType());
        }
    }
}