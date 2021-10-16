using Godot;
using System;

public class SecondaryActionPickup : Area2D
{
    [Export] public string Type;

    public override void _Ready()
    {
        this.GetNode<AnimatedSprite>("Sprite").Play(this.Type);
    }
    
    public PlayerSecondaryAction GetPickupType()
    {
        switch (this.Type)
        {
            case "roll":
                return PlayerSecondaryAction.FASTFALL_AND_ROLL;
            
            case "switchGravity":
                return PlayerSecondaryAction.SWITCH_GRAVITY;
            
            case "tpAndSwitchGravity":
                return PlayerSecondaryAction.TELEPORT_AND_SWITCH_GRAVITY;

            case "spawnPlatforms":
                return PlayerSecondaryAction.SPAWN_PLATFORMS;
            
            default:
                return PlayerSecondaryAction.FASTFALL_AND_ROLL;
        }
    }
}
