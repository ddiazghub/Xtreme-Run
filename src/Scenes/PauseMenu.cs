using Godot;
using System;

public class PauseMenu : NinePatchRect
{
    [Signal]
    public delegate void RestartPressed();

    public override void _Ready()
    {
        this.Hide();
        this.PauseMode = PauseModeEnum.Process;
        this.RectGlobalPosition = (Main.WINDOW_SIZE / 2) - (this.RectSize / 2);

        this.GetNode<TextureButton>("Cancel").Connect("pressed", this, nameof(this.OnCancelPressed));
        this.GetNode("Continue").Connect("pressed", this, nameof(this.OnContinuePressed));
        this.GetNode("Restart").Connect("pressed", this, nameof(this.OnRestartPressed));
        this.GetNode("Quit").Connect("pressed", this, nameof(this.OnQuitPressed));
    }

    public void OnCancelPressed()
    {
        this.OnContinuePressed();
    }

    public void OnContinuePressed()
    {
        this.GetTree().Paused = false;
        this.Hide();
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
        this.GetTree().Root.GetNode<Main>("Main").ChangeScene(GameScenes.MAIN_MENU);
    }
}
