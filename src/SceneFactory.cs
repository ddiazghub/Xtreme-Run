using Godot;
using System;
using System.Collections.Generic;

/// <summary>
///     This class generates scenes for the main class.
/// </summary>
public class SceneFactory {

    /// <summary>
    ///     A dictionary that maps each GameScenes enum value to it's corresponding scene.
    /// </summary>
    private Dictionary<GameScenes, PackedScene> scenes;

    /// <summary>
    ///     Creates a new scene factory. Loads each scene and stores it in the scenes dictionary.
    /// </summary>
    public SceneFactory()
    {
        this.scenes = new Dictionary<GameScenes, PackedScene>();
        this.scenes.Add(GameScenes.PROFILE_SELECT, ResourceLoader.Load<PackedScene>("res://src/Scenes/ProfileSelect.tscn"));
        this.scenes.Add(GameScenes.MAIN_MENU, ResourceLoader.Load<PackedScene>("res://src/Scenes/MainMenu.tscn"));
        this.scenes.Add(GameScenes.LEVEL1, ResourceLoader.Load<PackedScene>("res://src/Maps/Level1.tscn"));
        this.scenes.Add(GameScenes.LEVEL2, ResourceLoader.Load<PackedScene>("res://src/Maps/Level2.tscn"));
        this.scenes.Add(GameScenes.LEVEL3, ResourceLoader.Load<PackedScene>("res://src/Maps/Level3.tscn"));

    }

    /// <summary>
    ///     Creates a new scene.
    /// </summary>
    /// <param name="scene">The enum value of the scene to create.</param>
    /// <returns>A new instance of the scene.</returns>
    public Node2D New(GameScenes scene)
    {
        return this.scenes[scene].Instance<Node2D>();
    }
}