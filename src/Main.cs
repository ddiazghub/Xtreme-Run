using Godot;
using System;

using System.Collections.Generic;

public class Main : Node2D
{
    
    private Player _player;
    private Camera2D _camera;
    public List<Vector2> positions = new List<Vector2>();

    public override void _Ready()
    {
        this._player = this.GetNode<Player>("Player");
        this._camera = this.GetNode<Camera2D>("Camera");

        this._player.Connect("Dead", this, nameof(this.OnPlayerDead));

        this._camera.Position = this._player.Position;
    }

    public override void _Process(float delta)
    {
        this.Update();
        float newCameraY = this._camera.Position.y;

        if (this._player.Position.y < this._camera.Position.y - 140)
            newCameraY -= 7; 

        if (this._player.Position.y > this._camera.Position.y)
            newCameraY = this._player.Position.y;

        this._camera.Position = new Vector2(
            this._player.Position.x,
            newCameraY
        );
    }

    public override void _Draw()
    {
        this.positions.Add(this._player.Position);
        this.DrawPolyline(this.positions.ToArray(), Color.Color8(0, 0, 255));

    }

    public void OnPlayerDead()
    {
        this.positions.Clear();
        this._camera.Position = this._player.Position;
        this._player.Position = new Vector2(-1060.44f, 596.183f);
    }
}
