using Godot;
using System;

public class MainActionPickup : Area2D
{
    [Export] public string Type;

    public override void _Ready()
    {
        this.GetNode<AnimatedSprite>("Sprite").Play(this.Type);
    }

    public PlayerMainAction GetPickupType()
    {
        switch (this.Type)
        {
            case "jump":
                return PlayerMainAction.JUMP;
            
            case "jetpack":
                return PlayerMainAction.JETPACK;
            
            case "glide":
                return PlayerMainAction.GLIDE;

            case "teleport":
                return PlayerMainAction.TELEPORT;
            
            default:
                return PlayerMainAction.JUMP;
        }
    }
}
