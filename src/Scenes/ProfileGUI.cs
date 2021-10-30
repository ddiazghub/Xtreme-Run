using Godot;
using System;

public class ProfileGUI : NinePatchRect
{
    public override void _Ready()
    {
        Label label = this.GetNode<Label>("ProfileName");
        label.Text = Profile.CurrentSession.Info.Name;

        this.GetNode<TextureButton>("Shop").Connect("pressed", this, nameof(this.OnShopPressed));
        this.GetNode<TextureButton>("LogOut").Connect("pressed", this, nameof(this.OnLogOutPressed));
    }

    public void OnShopPressed()
    {

    }

    public void OnLogOutPressed()
    {
        Profile.CurrentSession.LogOut();
        this.GetTree().Root.GetNode<Main>("Main").ChangeScene(GameScenes.PROFILE_SELECT);
    }
}
