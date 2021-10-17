using Godot;
using System;
using System.Collections.Generic;

public class SceneFactory {
    private Dictionary<GameScenes, PackedScene> scenes;

    public SceneFactory()
    {
        this.scenes = new Dictionary<GameScenes, PackedScene>();
        this.scenes.Add(GameScenes.LEVEL1, ResourceLoader.Load<PackedScene>("res://src/Maps/Level1.tscn"));
        this.scenes.Add(GameScenes.LEVEL2, ResourceLoader.Load<PackedScene>("res://src/Maps/Level2.tscn"));
    }

    public Node2D New(GameScenes scene)
    {
        return this.scenes[scene].Instance<Node2D>();
    }
}