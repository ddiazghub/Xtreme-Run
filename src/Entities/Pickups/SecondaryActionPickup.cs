using Godot;
using System;

/// <summary>
///     Pickup for player secondary action.
/// </summary>
public class SecondaryActionPickup : Area2D
{
    /// <summary>
    ///     The pickup's type.
    /// </summary>
    private PlayerSecondaryAction type = PlayerSecondaryAction.FASTFALL_AND_ROLL;
    
    /// <summary>
    ///     The pickup's type.
    /// </summary>
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
