using Godot;
using System;

using System.Collections.Generic;

public class Main : Node2D
{
    private Node2D currentScene;
    private SceneFactory sceneFactory;

    public override void _Ready()
    {
        this.GetTree().DebugCollisionsHint = true;
        this.sceneFactory = new SceneFactory();
        this.ChangeScene(GameScenes.MAIN_MENU);
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
