using Godot;
using System;

public class Main : Node2D
{
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
        if (Profile.CurrentSession.Info != null)
            Profile.CurrentSession.Info.Avatar.Print();
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
