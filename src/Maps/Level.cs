using Godot;
using System;
using System.Collections.Generic;

public class Level : Node2D
{
    [Export]
    PackedScene Player;
    [Export]
    int LevelNumber = 0;
    [Export]
    float pointsMultiplier = 1f;
    private Player player;
    private Camera2D camera;
    private AnimatedSprite background;
    private PauseMenu pauseMenu;
    private LevelComplete levelCompleteMenu;
    private GameHUD hud;
    private Position2D startPosition;
    private Area2D endPosition;
    public List<Vector2> positions = new List<Vector2>();
    private int attemptCount = 0;
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

    public void UpdateProgress()
    {
        float distance = this.endPosition.Position.x - this.startPosition.Position.x;
        float currentDistance = this.player.Position.x - this.startPosition.Position.x;
        this.progress = (currentDistance / distance) * 100;

        if (this.progress > 100)
            this.progress = 100;
    }

    public int GetPoints()
    {
        return Mathf.Clamp((int) (this.progress - Profile.CurrentSession.Info.LevelProgress[this.LevelNumber]), 0, 100) * (int) (100 * this.pointsMultiplier);
    }
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

    public void Pause()
    {
        this.pauseMenu.ShowMenu();
    }

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
        this.player.blocked = true;
    }

    public void OnHudPauseMouseExited()
    {
        this.player.blocked = false;
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
