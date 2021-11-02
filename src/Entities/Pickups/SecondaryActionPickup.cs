using Godot;
using System;

public class SecondaryActionPickup : Area2D
{
    private PlayerSecondaryAction type = PlayerSecondaryAction.FASTFALL_AND_ROLL;
    
    [Export]
    public PlayerSecondaryAction Type
    {
        get
        {
            return this.type;
        }

        set
        {
            this.GetNode<AnimatedSprite>("Sprite").Play(SecondaryAction.GetTypeAsString(value));
            this.type = value;
        }
    }

    public override void _Ready()
    {
        this.GetNode<AnimatedSprite>("Sprite").Play(SecondaryAction.GetTypeAsString(this.Type));
    }
}
