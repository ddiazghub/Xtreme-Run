using Godot;
using System;

public class MainMenu : Node2D
{
    private TextureButton playButton;
    private TextureButton exitButton;
    private ConfirmationDialog exitPopup;

    public override void _Ready()
    {
        this.GetNode<AnimatedSprite>("Background").Play(Profile.CurrentSession.Info.CurrentLevel.ToString());

        this.playButton = this.GetNode<TextureButton>("GUI/VBoxContainer/Buttons/PlayButton");
        this.exitButton = this.GetNode<TextureButton>("GUI/VBoxContainer/Buttons/ExitButton");
        this.exitPopup = this.GetNode<ConfirmationDialog>("GUI/ExitGamePopup");

        this.playButton.Connect("pressed", this, nameof(this.OnPlayButtonPressed));
        this.exitButton.Connect("pressed", this, nameof(this.OnExitButtonPressed));
    }

    public override void _Process(float delta)
    {
        if (Input.IsActionPressed("ui_cancel"))
        {
            this.exitPopup.PopupCentered();
        }
    }
    public void OnPlayButtonPressed()
    {
        this.GetParent<Main>().ChangeScene(GameScenes.LEVEL_SELECT);
    }

    public void OnExitButtonPressed()
    {
        this.exitPopup.PopupCentered();
    }
}
