using Godot;
using System;

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
    }

    public override void _Process(float delta)
    {
        this.Update();
        this._camera.Position = new Vector2(
            this._player.Position.x,
            this._camera.Position.y
        );
    }

    public override void _Draw()
    {
        this.positions.Add(this._player.Position);
        this.DrawPolyline(this.positions.ToArray(), Color.Color8(0, 0, 255));
        GD.Print("Hello");
    }
}
