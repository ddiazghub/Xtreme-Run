using Godot;
using System;

public class MainMenu : Node2D
{
    private Button playButton;
    private Button shopButton;
    private Button exitButton;

    public override void _Ready()
    {
        this.playButton = this.GetNode<Button>("GUI/PlayButton");
        this.shopButton = this.GetNode<Button>("GUI/ShopButton");
        this.exitButton = this.GetNode<Button>("GUI/ExitButton");

        this.playButton.Connect("pressed", this, nameof(this.OnPlayButtonPressed));
        this.shopButton.Connect("pressed", this, nameof(this.OnShopButtonPressed));
        this.exitButton.Connect("pressed", this, nameof(this.OnExitButtonPressed));
    }

    public void OnPlayButtonPressed()
    {
        this.GetParent<Main>().ChangeScene(GameScenes.LEVEL_SELECT);
    }

    public void OnShopButtonPressed()
    {
        this.GetParent<Main>().ChangeScene(GameScenes.SHOP);
    }

    public void OnExitButtonPressed()
    {
        this.GetTree().Quit(0);
    }
}
