using Godot;
using System;

public class ProfileGUI : NinePatchRect
{
    [Signal]
    public delegate void ShopPressed();

    [Signal]
    public delegate void EditPressed();

    public override void _Ready()
    {
        this.GetNode("Shop").Connect("pressed", this, nameof(this.OnShopPressed));
        this.GetNode("LogOut").Connect("pressed", this, nameof(this.OnLogOutPressed));
        this.GetNode("Edit").Connect("pressed", this, nameof(this.OnEditPressed));

        this.UpdateUI();
    }

    public void UpdateUI()
    {
        this.GetNode<Label>("Completed").Text = Profile.CurrentSession.Info.CompletedLevels.Count + "/3 completado";
        this.GetNode<Label>("ProfileName").Text = Profile.CurrentSession.Info.Name;
        this.GetNode<TextureRect>("Avatar").Texture = Profile.CurrentSession.Info.Avatar.ToTexture();
    }

    public void OnShopPressed()
    {
        this.EmitSignal("ShopPressed");
    }

    public void OnEditPressed()
    {
        this.EmitSignal("EditPressed");
    }

    public void OnLogOutPressed()
    {
        Profile.CurrentSession.LogOut();
        this.GetTree().Root.GetNode<Main>("Main").ChangeScene(GameScenes.PROFILE_SELECT);
    }
}
