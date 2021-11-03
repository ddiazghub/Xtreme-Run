using Godot;
using System;

/// <summary>
///     Popup for the creation of new profiles.
/// </summary>
public class CreateProfileDialog : ConfirmationDialog {
    
    /// <summary>
    ///     Emitted if the profiled wasn't created succesfully.
    /// </summary>
    [Signal]
    public delegate void CreationFailed();

    /// <summary>
    ///     The id of the profile to create.
    /// </summary>
    private int profileID;

    public override void _Ready()
    {
        if (this.GetParent() is ProfileSelectEntry)
            this.profileID = this.GetParent<ProfileSelectEntry>().ProfileID;

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
            this.EmitSignal("CreationFailed");
            this.GetCancel().Pressed = true;
            
            return;
        }

        Profile.Create(this.profileID, name);
        PlayerSession.ActiveSession.Load(this.profileID);
        this.GetTree().Root.GetNode<Main>("Main").ChangeScene(GameScenes.MAIN_MENU);
    }

    public void OnCreateProfileDialogAboutToShow()
    {
        this.GetNode<LineEdit>("LineEdit").Clear();
    }
}
