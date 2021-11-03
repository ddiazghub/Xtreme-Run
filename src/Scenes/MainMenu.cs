using Godot;
using System;

/// <summary>
///     The main menu of the game.
/// </summary>
public class MainMenu : Node2D
{
    /// <summary>
    ///     The panel for editing the player's profile.
    /// </summary>
    private PackedScene editProfile = ResourceLoader.Load<PackedScene>("res://src/Scenes/EditProfileGUI.tscn");
    
    /// <summary>
    ///     The panel that contains the game's shop.
    /// </summary>
    private PackedScene shop = ResourceLoader.Load<PackedScene>("res://src/Scenes/ShopGUI.tscn");

    public override void _Ready()
    {
        this.GetNode<TextureButton>("GUI/VBoxContainer/Buttons/PlayButton").Connect("pressed", this, nameof(this.OnPlayButtonPressed));
        this.GetNode<TextureButton>("GUI/VBoxContainer/Buttons/ExitButton").Connect("pressed", this, nameof(this.OnExitButtonPressed));
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
            this.GetNode<ConfirmationDialog>("GUI/ExitGamePopup").PopupCentered();
        }
    }

    public void UpdateUI()
    {
        this.GetNode<PointsCounter>("GUI/PointsCounter").Set(PlayerSession.ActiveSession.Profile.Points);
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
        this.GetNode<ConfirmationDialog>("GUI/ExitGamePopup").PopupCentered();
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
