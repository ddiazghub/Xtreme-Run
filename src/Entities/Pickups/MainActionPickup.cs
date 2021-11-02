using Godot;
using System;

/// <summary>
///     Pickup for player main action.
/// </summary>
public class MainActionPickup : Area2D
{
    /// <summary>
    ///     The pickup's type.
    /// </summary>
    private PlayerMainAction type = PlayerMainAction.JUMP;

    /// <summary>
    ///     The pickup's type.
    /// </summary>
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
