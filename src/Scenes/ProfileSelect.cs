using Godot;
using System;

/// <summary>
///     Scene that displays a menu where profiles can be created, loaded and deleted.
/// </summary>
public class ProfileSelect : Node2D
{
    /// <summary>
    ///     Popups that confirms if the player wants to quit the game.
    /// </summary>
    private ExitGamePopup exitPopup;

    public override void _Ready()
    {
        this.exitPopup = this.GetNode<ExitGamePopup>("GUI/ExitGamePopup");
    }

    public override void _Process(float delta)
    {
        if (Input.IsActionPressed("ui_cancel"))
        {
            this.exitPopup.PopupCentered();
        }
    }
}
