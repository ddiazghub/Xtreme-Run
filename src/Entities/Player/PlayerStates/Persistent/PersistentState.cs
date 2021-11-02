using Godot;
using System;

/// <summary>
///     Class that represents a player persistent state.
///     Can be on air or on ground.
/// </summary>
public abstract class PersistentState: PlayerState {


    public override void _Init()
    {
        this.Player.jumpObjectCollisionCheck.Connect("area_entered", this, nameof(this.OnActionObjectCollisionCheckAreaEntered));
    }

    public override void _StatePhysicsProcess(float delta)
    {
        if (this.Player.Position.y > 4000 || this.Player.Position.y < -4000)
            this.Player.EmitSignal("Dead");

        if (!this.Player.Invincible)
        {
            if (this.Player.IsOnWall() || this.Player.IsOnCeiling())
            {
                this.Player.EmitSignal("Dead");
            }


            for (int i = 0; i < this.Player.GetSlideCount(); i++)
            {
                if (((Node) this.Player.GetSlideCollision(i).Collider).IsInGroup("hazard"))
                {
                    this.Player.EmitSignal("Dead");
                }
            }
        }

        this.Player.linearVelocity.x = this.Player.MovementSpeed;
    }

    public void OnActionObjectCollisionCheckAreaEntered(Area2D area)
    {
        if (area.IsInGroup("pickup_main"))
        {
            this.Player.ChangeMainAction(((MainActionPickup) area).Type);   
        }

        if (area.IsInGroup("pickup_secondary"))
        {
            this.Player.ChangeSecondaryAction(((SecondaryActionPickup) area).Type);
        }
    }
}