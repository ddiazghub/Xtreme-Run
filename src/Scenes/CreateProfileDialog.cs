using Godot;
using System;

public class CreateProfileDialog : ConfirmationDialog
{
    public int profileID;

    public override void _Ready()
    {
        this.GetOk().Text = "Confirmar";
        this.GetCancel().Text = "Cancelar";

        this.Connect("confirmed", this, nameof(this.OnCreateProfileDialogConfirmed));
        this.Connect("about_to_show", this, nameof(this.OnCreateProfileDialogAboutToShow));
    }

    public void OnCreateProfileDialogConfirmed()
    {
        string name = this.GetNode<LineEdit>("LineEdit").Text;

        if (!Profile.NameIsAvailable(name))
        {
            this.GetParent().GetNode<AcceptDialog>("FailedAlert").PopupCentered();
            this.GetCancel().Pressed = true;
            
            return;
        }

        Profile.Create(this.profileID, name);
        Profile.CurrentSession.Load(this.profileID);
        this.GetParent().GetParent().GetParent<Main>().ChangeScene(GameScenes.MAIN_MENU);
    }

    public void OnCreateProfileDialogAboutToShow()
    {
        this.GetNode<LineEdit>("LineEdit").Clear();
    }
}
