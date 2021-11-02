using Godot;
using System;

/// <summary>
///     The hud that shows when the player is in a level.
/// </summary>
public class GameHUD : CanvasLayer
{
    /// <summary>
    ///     Signal emitted when the pause button is pressed.
    /// </summary>
    [Signal]
    public delegate void PausePressed();
    
    /// <summary>
    ///     Signal emitted when the mouse enters the pause button area.
    /// </summary>
    [Signal]
    public delegate void PauseMouseEntered();
    
    /// <summary>
    ///     Signal emitted when the mouse exits the pause button area.
    /// </summary>
    [Signal]
    public delegate void PauseMouseExited();

    public override void _Ready()
    {
        this.GetNode("Pause").Connect("pressed", this, nameof(this.OnPausePressed));
        this.GetNode("Pause").Connect("mouse_entered", this, nameof(this.OnPauseMouseEntered));
        this.GetNode("Pause").Connect("mouse_exited", this, nameof(this.OnPauseMouseExited));
    }

    /// <summary>
    ///     Sets the number of points to display in the points counter.
    /// </summary>
    /// <param name="points">The new number of points to display.</param>
    public void SetPoints(int points)
    {
        this.GetNode<PointsCounter>("PointsCounter").Set((UInt32) points);
    }

    /// <summary>
    ///        Sets the progress to display in the level progress bar.
    /// </summary>
    /// <param name="percent">The player's new progress.</param>
    public void SetProgress(double percent)
    {
        this.GetNode<ProgressBar>("Progress").Value = percent;
    }

    /// <summary>
    ///     Sets the number of attempts to display on the attempts counter.
    /// </summary>
    /// <param name="number">The player's new number of attempts.</param>
    public void SetAttempts(int number)
    {
        this.GetNode<AttemptsCounter>("AttemptsCounter").Set(number);
    }

    /// <summary>
    ///     Sets the player actions to display on the hud.
    /// </summary>
    /// <param name="main">The main action the player currently has.</param>
    /// <param name="secondary">The secondary action the player currently has.</param>
    public void SetActions(PlayerMainAction main, PlayerSecondaryAction secondary)
    {
        if (main != this.GetNode<MainActionPickup>("MainAction").Type)
        {
        this.GetNode<MainActionPickup>("MainAction").Type = main;
        this.GetNode<Label>("MainAction/MainLabel").Text = MainAction.GetTypeAsStringEsp(main);
        }
        
        if (secondary != this.GetNode<SecondaryActionPickup>("SecondaryAction").Type)
        {
            this.GetNode<SecondaryActionPickup>("SecondaryAction").Type = secondary;
            this.GetNode<Label>("SecondaryAction/SecondaryLabel").Text = SecondaryAction.GetTypeAsStringEsp(secondary);
        }
    }

    public void OnPausePressed()
    {
        this.EmitSignal("PausePressed");
    }

    public void OnPauseMouseEntered()
    {
        this.EmitSignal("PauseMouseEntered");
    }
    
    public void OnPauseMouseExited()
    {
        this.EmitSignal("PauseMouseExited");
    }
}
