using Godot;
using System;

/// <summary>
///     Button that and allows the profile to be selected and displays a profile's data.
/// </summary>
public class ProfileSelectEntry : Button {

    /// <summary>
    ///     The profile's id.
    /// </summary>
    [Export]
    public int ProfileID = 0;

    public override void _Ready()
    {
        this.GetNode<CreateProfileDialog>("Front/CreateProfileDialog").Connect("CreationFailed", this, nameof(this.OnCreateDialogCreationFailed));
        this.GetNode<ConfirmationDialog>("Front/DeleteDialog").GetOk().Text = "Confimar";
        this.GetNode<ConfirmationDialog>("Front/DeleteDialog").GetCancel().Text = "Cancelar";

        this.GetNode("Front/DeleteDialog").Connect("confirmed", this, nameof(this.OnDeleteDialogConfirmed));
        this.GetNode("Delete").Connect("pressed", this, nameof(this.OnDeletePressed));
        this.Connect("pressed", this, nameof(this.OnPressed));
        this.UpdateUI();
    }

    /// <summary>
    ///     Updates the data currently displayed on the button.
    /// </summary>
    public void UpdateUI()
    {
        if (Profile.Exists(this.ProfileID))
        {
            ProfileInfo save = Profile.Get(this.ProfileID);

            this.GetNode<Label>("Completed").Text = save.CompletedLevels.Count + "/3 completado";
            this.GetNode<Label>("Objects").Text = save.NumberOfOwnedItems + "/17 objetos";
            this.GetNode<Label>("ProfileName").Text = save.Name;
            this.GetNode<TextureRect>("Avatar").Texture = save.Avatar.ToTexture();
        }
        else
        {
            this.GetNode<TextureButton>("Delete").Disabled = true;
            this.GetNode<Label>("Completed").Text = "0/3 completado";
            this.GetNode<Label>("Objects").Text = "0/17 objetos";
            this.GetNode<Label>("ProfileName").Text = "Disponible";
            this.GetNode<TextureRect>("Avatar").Texture = Avatar.EMPTY_SAVE_AVATAR;
        }
    }

    public void OnDeletePressed()
    {
        this.GetNode<ConfirmationDialog>("Front/DeleteDialog").PopupCentered();
    }

    public void OnDeleteDialogConfirmed()
    {
        Profile.Delete(this.ProfileID);
        this.UpdateUI();
    }

    public void OnCreateDialogCreationFailed()
    {
        this.GetNode<AcceptDialog>("Front/FailedAlert").PopupCentered();
    }

    public void OnPressed()
    {
        if (Profile.Exists(this.ProfileID))
        {
            Profile.CurrentSession.Load(this.ProfileID);
            this.GetTree().Root.GetNode<Main>("Main").ChangeScene(GameScenes.MAIN_MENU);
        }
        else
        {
            this.GetNode<CreateProfileDialog>("Front/CreateProfileDialog").PopupCentered();
        }
    }
}
