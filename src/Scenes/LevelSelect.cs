using Godot;
using System;

public class LevelSelect : Node2D
{
    private Button returnButton;
    private Button level1Button;
    private Button level2Button;
    private Button level3Button;
    private Button level4Button;

    public override void _Ready()
    {
        this.returnButton = this.GetNode<Button>("GUI/ReturnButton");
        this.level1Button = this.GetNode<Button>("GUI/Level1Button");
        this.level2Button = this.GetNode<Button>("GUI/Level2Button");
        this.level3Button = this.GetNode<Button>("GUI/Level3Button");
        this.level4Button = this.GetNode<Button>("GUI/Level4Button");

        this.returnButton.Connect("pressed", this, nameof(this.OnReturnButtonPressed));
        this.level1Button.Connect("pressed", this, nameof(this.OnLevel1ButtonPressed));
        this.level2Button.Connect("pressed", this, nameof(this.OnLevel2ButtonPressed));
        this.level3Button.Connect("pressed", this, nameof(this.OnLevel3ButtonPressed));
        this.level4Button.Connect("pressed", this, nameof(this.OnLevel4ButtonPressed));
    }

    public void OnReturnButtonPressed()
    {
        this.GetParent<Main>().ChangeScene(GameScenes.MAIN_MENU);
    }

    public void OnLevel1ButtonPressed()
    {
        this.GetParent<Main>().ChangeScene(GameScenes.LEVEL1);
    }

    public void OnLevel2ButtonPressed()
    {
        this.GetParent<Main>().ChangeScene(GameScenes.LEVEL2);
    }

    public void OnLevel3ButtonPressed()
    {
        this.GetParent<Main>().ChangeScene(GameScenes.LEVEL3);
    }

    public void OnLevel4ButtonPressed()
    {
        this.GetParent<Main>().ChangeScene(GameScenes.LEVEL4);
    }
}
