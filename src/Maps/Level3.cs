using Godot;
using System;
using System.Collections.Generic;

public class Level3 : Node2D
{
    private Vector2 startPos;
    private Player player;
    private Camera2D camera;
    private Sprite background;
    public List<Vector2> positions = new List<Vector2>();

    public override void _Ready()
    {
        this.player = this.GetNode<Player>("Player");
        this.camera = this.GetNode<Camera2D>("Camera");
        this.background = this.GetNode<Sprite>("Background");

        this.player.Connect("Dead", this, nameof(this.OnPlayerDead));

        if (this.startPos == new Vector2(0, 0))
        {
            this.startPos = this.player.Position;
        }

        this.camera.Position = this.player.Position;
    }

    public override void _Process(float delta)
    {
        GD.Print("Linear velocity: " + this.player.linearVelocity.ToString());
        GD.Print("Gravity: " + this.player.gravity);
        GD.Print("Jump Force: " + this.player.jumpForce);
        GD.Print("Max Jump time: " + this.player.maxJumpTime);
        GD.Print("Max fall Speed: " + this.player.maxFallSpeed);
        GD.Print("Persistent State: " + this.player.persistentState.GetType());

        this.Update();
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

    public override void _Draw()
    {
        this.positions.Add(this.player.Position);

        if (this.positions.Count > 2) 
            this.DrawPolyline(this.positions.ToArray(), Color.Color8(0, 0, 255));

    }

    public void OnPlayerDead()
    {
        this.positions.Clear();
        this.player.Position = this.startPos;
        this.camera.Position = this.player.Position;
        this.player._Ready();
    }
}
