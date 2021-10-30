using Godot;
using System;

public class CreateProfileDialog : ConfirmationDialog
{
    public int profileID;

    public override void _Ready()
    {
        this.GetOk().Text = "Confirmar";
        this.GetCancel().Text = "Cancelar";

        this.Connect("confirmed", this, nameof(this.OnExitGamePopupConfirmed));
        this.Connect("about_to_show", this, nameof(this.OnExitGamePopupAboutToShow));
    }

    public void OnExitGamePopupConfirmed()
    {
        Profile.Create(this.profileID, this.GetNode<LineEdit>("LineEdit").Text);
        Profile.CurrentSession.Load(this.profileID);
        this.GetParent().GetParent().GetParent<Main>().ChangeScene(GameScenes.MAIN_MENU);
    }

    public void OnExitGamePopupAboutToShow()
    {
        this.GetNode<LineEdit>("LineEdit").Clear();
    }
}
