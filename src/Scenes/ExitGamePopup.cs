using Godot;
using System;

/// <summary>
///     Confirms if the player wants to exit the game.
/// </summary>
public class ExitGamePopup : ConfirmationDialog
{
    public override void _Ready()
    {
        this.GetOk().Text = "Confirmar";
        this.GetCancel().Text = "Cancelar";

        this.Connect("confirmed", this, nameof(this.OnExitGamePopupConfirmed));
    }

    public void OnExitGamePopupConfirmed()
    {
        this.GetTree().Quit(0);
    }
}
