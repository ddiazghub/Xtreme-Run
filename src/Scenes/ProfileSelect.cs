using Godot;
using System;

public class ProfileSelect : Node2D
{
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
