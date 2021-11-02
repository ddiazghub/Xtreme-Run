using Godot;
using System;

/// <summary>
///     Menu that will be shown when a level is completed.
/// </summary>
public class LevelComplete : NinePatchRect {

    /// <summary>
    ///     Signal that will be emitted when the restart button is pressed.
    /// </summary>
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

    /// <summary>
    ///     Pauses the game and shows this menu.
    /// </summary>
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
        ((Level) this.GetTree().Root.GetNode<Main>("Main").Scene).SaveData();
        this.GetTree().Root.GetNode<Main>("Main").ChangeScene(GameScenes.MAIN_MENU);
    }
}
