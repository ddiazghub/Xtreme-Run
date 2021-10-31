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
        Label label = this.GetNode<Label>("ProfileName");
        label.Text = Profile.CurrentSession.Info.Name;

        this.GetNode("Shop").Connect("pressed", this, nameof(this.OnShopPressed));
        this.GetNode("LogOut").Connect("pressed", this, nameof(this.OnLogOutPressed));
        this.GetNode("Edit").Connect("pressed", this, nameof(this.OnEditPressed));
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
