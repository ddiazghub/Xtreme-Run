using Godot;
using System;
using System.Collections.Generic;

/// <summary>
///     Node for playing audio globally in the game.
/// </summary>
public class GameAudio : Node2D
{
    /// <summary>
    ///     Music to play on menus.
    /// </summary>
    [Export]
    public AudioStream MenuMusic;

    /// <summary>
    ///     Level 1 music.
    /// </summary>
    [Export]
    public AudioStream Level1Music;

    /// <summary>
    ///     Level 2 music.
    /// </summary>
    [Export]
    public AudioStream Level2Music;

    /// <summary>
    ///     Level 3 music.
    /// </summary>
    [Export]
    public AudioStream Level3Music;

    /// <summary>
    ///     Audio effect to play when clicking an accept button.
    /// </summary>
    [Export]
    public AudioStream AcceptSFX;

    /// <summary>
    ///     Audio effect to play when clicking an cancel/back button.
    /// </summary>
    [Export]
    public AudioStream CancelSFX;

    /// <summary>
    ///     Dictionary mapping each game scene to a background music track.
    /// </summary>
    private Dictionary<GameScenes, AudioStream> sceneMusic;

    /// <summary>
    ///     The audio player for background music.
    /// </summary>
    private AudioStreamPlayer music;

    /// <summary>
    ///     The audio player for audio effects.
    /// </summary>
    private AudioStreamPlayer sfx;

    public override void _Ready()
    {
        this.sceneMusic = new Dictionary<GameScenes, AudioStream>();
        this.sceneMusic.Add(GameScenes.MAIN_MENU, this.MenuMusic);
        this.sceneMusic.Add(GameScenes.PROFILE_SELECT, this.MenuMusic);
        this.sceneMusic.Add(GameScenes.LEVEL1, this.Level1Music);
        this.sceneMusic.Add(GameScenes.LEVEL2, this.Level2Music);
        this.sceneMusic.Add(GameScenes.LEVEL3, this.Level3Music);

        this.music = this.GetNode<AudioStreamPlayer>("Music");
        this.sfx = this.GetNode<AudioStreamPlayer>("SFX");

        this.music.Connect("finished", this, nameof(this.OnMusicFinished));
        this.sfx.Connect("finished", this, nameof(this.OnSfxFinished));

        this.music.Stream = this.MenuMusic;
        this.music.Play();
    }

    /// <summary>
    ///     Sets a new music track, depending on the scene.
    /// </summary>
    /// <param name="scene">The new scene executed by the main scene.</param>
    public void SetMusic(GameScenes scene)
    {
        AudioStream stream = this.sceneMusic[scene];

        if (stream == this.music.Stream)
            return;

        this.music.Stream = stream;
        this.music.Play();
    }

    /// <summary>
    ///     Plays the accept audio effect.
    /// </summary>
    public void PlayAccept()
    {
        this.sfx.Stream = this.AcceptSFX;
        this.sfx.Play();
    }

    /// <summary>
    ///     Plays the cancel audio effect.
    /// </summary>
    public void PlayCancel()
    {
        this.sfx.Stream = this.CancelSFX;
        this.sfx.Play();
    }

    public void OnMusicFinished()
    {
        this.music.Play();
    }

    public void OnSfxFinished()
    {
        this.sfx.Stop();
    }
}
