using Godot;
using System;

/// <summary>
///     The main Node of the game.
///     It is a state machine that executes a single scene at a time.
/// </summary>
public class Main : Node2D {

    /// <summary>
    ///     Size of the game's window.
    /// </summary>
    public static readonly Vector2 WINDOW_SIZE = new Vector2(1280, 720);

    /// <summary>
    ///     The scene currently being executed. Can be profile select, main menu, level 1, level 2 or level 3.
    /// </summary>
    public Node2D Scene
    {
        get;
        private set;
    }

    /// <summary>
    ///     Factory for creating new scene instances.
    /// </summary>
    private SceneFactory sceneFactory;

    public override void _Ready()
    {
        this.GetTree().DebugCollisionsHint = true;
        this.sceneFactory = new SceneFactory();
        this.ChangeScene(GameScenes.PROFILE_SELECT);
    }

    /// <summary>
    ///     Changes the currently active game scene.
    /// </summary>
    /// <param name="scene">The new scene.</param>
    public void ChangeScene(GameScenes scene)
    {
        if (this.Scene != null)
        {
            this.Scene.QueueFree();
        }

        this.Scene = this.sceneFactory.New(scene);
        this.AddChild(this.Scene);
    }
}
