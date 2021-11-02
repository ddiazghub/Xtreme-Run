using Godot;
using System;

public class MainMenu : Node2D
{
    private PackedScene editProfile = ResourceLoader.Load<PackedScene>("res://src/Scenes/EditProfileGUI.tscn");
    private PackedScene shop = ResourceLoader.Load<PackedScene>("res://src/Scenes/ShopGUI.tscn");
    private TextureButton playButton;
    private TextureButton exitButton;
    private ConfirmationDialog exitPopup;

    public override void _Ready()
    {
        this.playButton = this.GetNode<TextureButton>("GUI/VBoxContainer/Buttons/PlayButton");
        this.exitButton = this.GetNode<TextureButton>("GUI/VBoxContainer/Buttons/ExitButton");
        this.exitPopup = this.GetNode<ConfirmationDialog>("GUI/ExitGamePopup");

        this.playButton.Connect("pressed", this, nameof(this.OnPlayButtonPressed));
        this.exitButton.Connect("pressed", this, nameof(this.OnExitButtonPressed));
        this.GetNode("GUI/ProfileGUI").Connect("ShopPressed", this, nameof(this.OnProfileGUIShopPressed));
        this.GetNode("GUI/ProfileGUI").Connect("EditPressed", this, nameof(this.OnProfileGUIEditPressed));
        this.GetNode("GUI/LevelPicker").Connect("ValueChanged", this, nameof(this.OnLevelPickerValueChanged));

        this.GetNode<AnimatedSprite>("Background").Play(((int) this.GetNode<SpinBox>("GUI/LevelPicker").Value - 1).ToString());
        this.GetNode<LevelPicker>("GUI/LevelPicker").GetLineEdit().MouseFilter = Control.MouseFilterEnum.Ignore;

        this.UpdateUI();
    }

    public override void _Process(float delta)
    {
        if (Input.IsActionPressed("ui_cancel"))
        {
            this.exitPopup.PopupCentered();
        }
    }

    public void UpdateUI()
    {
        this.GetNode<PointsCounter>("GUI/PointsCounter").Set(Profile.CurrentSession.Info.Points);
        this.GetNode<ProfileGUI>("GUI/ProfileGUI").UpdateUI();
    }

    public void OnPlayButtonPressed()
    {
        this.GetParent<Main>().ChangeScene((GameScenes) Enum.Parse(typeof(GameScenes), "LEVEL" + (int) this.GetNode<SpinBox>("GUI/LevelPicker").Value));
    }

    public void OnProfileGUIShopPressed()
    {
        ShopGUI gui = this.shop.Instance<ShopGUI>();
        this.GetNode("GUI").AddChild(gui);
        gui.Connect("ProfileChanged", this, nameof(this.OnProfileChanged));
    }

    public void OnProfileGUIEditPressed()
    {
        EditProfileGUI gui = this.editProfile.Instance<EditProfileGUI>();
        this.GetNode("GUI").AddChild(gui);
        gui.Connect("ProfileChanged", this, nameof(this.OnProfileChanged));
    }

    public void OnExitButtonPressed()
    {
        this.exitPopup.PopupCentered();
    }

    public void OnProfileChanged()
    {
        this.UpdateUI();
    }

    public void OnLevelPickerValueChanged()
    {
        this.GetNode<AnimatedSprite>("Background").Play(((int) this.GetNode<LevelPicker>("GUI/LevelPicker").Value - 1).ToString());
    }
}
