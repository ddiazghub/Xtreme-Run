using Godot;
using System;

public class LevelComplete : NinePatchRect
{
    [Signal]
    public delegate void RestartPressed();

    public override void _Ready()
    {
        this.Hide();
        this.PauseMode = PauseModeEnum.Process;
        this.RectGlobalPosition = (Main.WINDOW_SIZE / 2) - (this.RectSize / 2);

        this.GetNode("Restart").Connect("pressed", this, nameof(this.OnRestartPressed));
        this.GetNode("Quit").Connect("pressed", this, nameof(this.OnQuitPressed));
    }

    public void ShowMenu()
    {
        this.Show();
        this.GetTree().Paused = true;
    }

    public void OnRestartPressed()
    {
        this.EmitSignal("RestartPressed");
        this.GetTree().Paused = false;
        this.Hide();
    }

    public void OnQuitPressed()
    {
        this.GetTree().Paused = false;
        this.EmitSignal("QuitPressed");
        ((Level) this.GetTree().Root.GetNode<Main>("Main").currentScene).SaveData();
        this.GetTree().Root.GetNode<Main>("Main").ChangeScene(GameScenes.MAIN_MENU);
    }
}
