using Godot;
using System;

public class Main : Node2D
{
    public static readonly Vector2 WINDOW_SIZE = new Vector2(1280, 720);
    private Node2D currentScene;
    private SceneFactory sceneFactory;

    public override void _Ready()
    {
        this.GetTree().DebugCollisionsHint = true;
        this.sceneFactory = new SceneFactory();
        this.ChangeScene(GameScenes.PROFILE_SELECT);
    }

    public override void _Process(float delta)
    {
    }

    public void ChangeScene(GameScenes scene)
    {
        if (this.currentScene != null)
        {
            this.currentScene.QueueFree();
        }

        this.currentScene = this.sceneFactory.New(scene);
        this.AddChild(this.currentScene);
    }
}
