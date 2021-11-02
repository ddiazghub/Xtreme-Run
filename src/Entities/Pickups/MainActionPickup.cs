using Godot;
using System;

public class MainActionPickup : Area2D
{
    private PlayerMainAction type = PlayerMainAction.JUMP;

    [Export] public PlayerMainAction Type
    {
        get
        {
            return this.type;
        }

        set
        {
            this.GetNode<AnimatedSprite>("Sprite").Play(MainAction.GetTypeAsString(value));
            this.type = value;
        }
    }

    public override void _Ready()
    {
        this.GetNode<AnimatedSprite>("Sprite").Play(MainAction.GetTypeAsString(this.Type));
    }
}
