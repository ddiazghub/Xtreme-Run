using Godot;
using System;
using System.Collections.Generic;

/// <summary>
///     Base node for a game level scene.
/// </summary>
public class Level : Node2D
{
    /// <summary>
    ///     The player scene from which to load instances.
    /// </summary>
    [Export]
    PackedScene Player;

    /// <summary>
    ///     The level's number.
    /// </summary>
    [Export]
    int LevelNumber = 0;

    /// <summary>
    ///     A value that will be multiplied with the points earned.
    /// </summary>
    [Export]
    float pointsMultiplier = 1f;

    /// <summary>
    ///     The currently active player in the level.
    /// </summary>
    private Player player;

    /// <summary>
    ///     The game's camera.
    /// </summary>
    private Camera2D camera;

    /// <summary>
    ///     The level's background.
    /// </summary>
    private AnimatedSprite background;

    /// <summary>
    ///     The level's pause menu.
    /// </summary>
    private PauseMenu pauseMenu;

    /// <summary>
    ///     Menu that will be shown when level is completed.
    /// </summary>
    private LevelComplete levelCompleteMenu;

    /// <summary>
    ///     Game hud.
    /// </summary>
    private GameHUD hud;

    /// <summary>
    ///     The player's spawn position.
    /// </summary>
    private Position2D startPosition;

    /// <summary>
    ///     The player's position where the level ends.
    /// </summary>
    private Area2D endPosition;


    public List<Vector2> positions = new List<Vector2>();

    /// <summary>
    ///     The number of times the player has attempted the level.
    /// </summary>
    private int attemptCount = 0;

    /// <summary>
    ///     The current progress the player has on the level.
    /// </summary>
    private double progress = 0;

    public override void _Ready()
    {
        this.camera = this.GetNode<Camera2D>("Camera");
        this.background = this.GetNode<AnimatedSprite>("Background");
        this.pauseMenu = this.GetNode<PauseMenu>("Front/PauseMenu");
        this.hud = this.GetNode<GameHUD>("GameHUD");
        this.startPosition = this.GetNode<Position2D>("Start");
        this.endPosition = this.GetNode<Area2D>("End");
        this.levelCompleteMenu = this.GetNode<LevelComplete>("Front/LevelComplete");

        this.hud.Connect("PausePressed", this, nameof(this.OnHudPausePressed));
        this.hud.Connect("PauseMouseEntered", this, nameof(this.OnHudPauseMouseEntered));
        this.hud.Connect("PauseMouseExited", this, nameof(this.OnHudPauseMouseExited));
        this.pauseMenu.Connect("RestartPressed", this, nameof(this.OnPauseMenuRestartPressed));
        this.levelCompleteMenu.Connect("RestartPressed", this, nameof(this.OnPauseMenuRestartPressed));
        this.endPosition.Connect("body_entered", this, nameof(this.OnEndPositionBodyEntered));

        this.background.Play(this.LevelNumber.ToString());
        this.Restart();
    }

    public override void _Process(float delta)
    {
        this.Update();
        this.MoveViewPort();
        this.UpdateProgress();

        if (Input.IsActionPressed("ui_cancel"))
        {
            this.Pause();
        }

        this.hud.SetActions(this.player.mainActionType, this.player.secondaryActionType);
        this.hud.SetProgress(this.progress);
        this.hud.SetPoints(this.GetPoints());
    }

    public override void _Draw()
    {
        this.positions.Add(this.player.Position);

        if (this.positions.Count > 2) 
            this.DrawPolyline(this.positions.ToArray(), Color.Color8(255, 255, 255));
    }

    /// <summary>
    ///     Restarts the level, resets the player's position and the hud.
    /// </summary>
    public void Restart()
    {
        this.SaveData();

        if (this.player != null)
        {
            this.player.QueueFree();
        }

        this.attemptCount++;
        this.hud.SetAttempts(this.attemptCount);

        this.player = this.Player.Instance<Player>();
        this.AddChild(this.player);
        this.player.Name = "Player";
        this.player.Position = this.startPosition.Position;
        this.camera.Position = this.player.Position;
        this.positions.Clear();

        this.player.Connect("Dead", this, nameof(this.OnPlayerDead));
    }

    /// <summary>
    ///     Calculates the progress that the player currently has on the level.
    /// </summary>
    public void UpdateProgress()
    {
        float distance = this.endPosition.Position.x - this.startPosition.Position.x;
        float currentDistance = this.player.Position.x - this.startPosition.Position.x;
        this.progress = (currentDistance / distance) * 100;

        if (this.progress > 100)
            this.progress = 100;
    }

    /// <summary>
    ///     Gets the number of points that the player has earned on the current run.
    /// </summary>
    /// <returns></returns>
    public int GetPoints()
    {
        return Mathf.Clamp((int) (this.progress - Profile.CurrentSession.Info.LevelProgress[this.LevelNumber]), 0, 100) * (int) (100 * this.pointsMultiplier);
    }

    /// <summary>
    ///     Moves the camera and the background to follow the player.
    /// </summary>
    public void MoveViewPort()
    {
        float newCameraY = this.camera.Position.y;

        if (this.player.Position.y < this.camera.Position.y - 140)
            newCameraY -= 10; 

        if (this.player.Position.y > this.camera.Position.y)
            newCameraY = this.player.Position.y;

        this.camera.Position = new Vector2(
            this.player.Position.x,
            newCameraY
        );

        this.background.Position = this.camera.Position;
    }

    /// <summary>
    ///     Pauses the game.
    /// </summary>
    public void Pause()
    {
        this.pauseMenu.ShowMenu();
    }

    /// <summary>
    ///     Saves the player's progress.
    /// </summary>
    public void SaveData()
    {
        if (this.progress > Profile.CurrentSession.Info.LevelProgress[this.LevelNumber])
        {
            Profile.CurrentSession.Info.Points += (UInt32) this.GetPoints();
            Profile.CurrentSession.Info.LevelProgress[this.LevelNumber] = (int) this.progress;
            Profile.CurrentSession.Save();
        }
    }

    public void OnPlayerDead()
    {
        this.Restart();
    }

    public void OnHudPausePressed()
    {
        this.Pause();
    }

    public void OnHudPauseMouseEntered()
    {
        this.player.Blocked = true;
    }

    public void OnHudPauseMouseExited()
    {
        this.player.Blocked = false;
    }

    public void OnPauseMenuRestartPressed()
    {
        this.Restart();
    }

    public void OnEndPositionBodyEntered(Node body)
    {
        if (body.IsInGroup("player"))
        {
            this.levelCompleteMenu.ShowMenu();
        }
    }
}
