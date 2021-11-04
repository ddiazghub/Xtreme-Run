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

    private GameAudio gameAudio;

    /// <summary>
    ///     Factory for creating new scene instances.
    /// </summary>
    private SceneFactory sceneFactory;

    public override void _Ready()
    {
        this.sceneFactory = new SceneFactory();
        this.gameAudio = this.GetNode<GameAudio>("GameAudio");

        this.GetTree().DebugCollisionsHint = true;
        this.ChangeScene(GameScenes.PROFILE_SELECT);
    }

    /// <summary>
    ///     Changes the currently active game scene and modifies the sounds currently being played accordingly.
    /// </summary>
    /// <param name="scene">The new scene.</param>
    public void ChangeScene(GameScenes scene)
    {
        if (this.Scene != null)
        {
            this.gameAudio.SetMusic(scene);

            if ((this.Scene is ProfileSelect && scene == GameScenes.MAIN_MENU) ||
                (this.Scene is MainMenu && (scene == GameScenes.LEVEL1 || scene == GameScenes.LEVEL2 || scene == GameScenes.LEVEL3)))
            {
                this.gameAudio.PlayAccept();
            }
            else if ((this.Scene is MainMenu && scene == GameScenes.PROFILE_SELECT) || (this.Scene is Level && scene == GameScenes.MAIN_MENU))
            {
                this.gameAudio.PlayCancel();
            }

            this.Scene.QueueFree();
        }

        this.Scene = this.sceneFactory.New(scene);
        this.AddChild(this.Scene);

        if (this.Scene is Level)
        {
            this.Scene.Connect("PlayerDead", this, nameof(this.OnPlayerDead));
            this.Scene.Connect("PlayerPickup", this, nameof(this.OnPlayerPickup));
            this.Scene.Connect("PlayerPerformedMainAction", this, nameof(this.OnPlayerPerformedMainAction));
            
        }
    }

    public void OnPlayerDead()
    {
        this.gameAudio.PlayDeath();
    }

    public void OnPlayerPickup()
    {
        this.gameAudio.PlayPickup();
    }

    public void OnPlayerPerformedMainAction()
    {
        this.gameAudio.PlayJump();
    }
}
