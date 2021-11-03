using Godot;
using System;
using System.Collections.Generic;

public class GameAudio : Node2D
{
    [Export]
    public AudioStream MenuMusic;

    [Export]
    public AudioStream Level1Music;

    [Export]
    public AudioStream Level2Music;

    [Export]
    public AudioStream Level3Music;

    [Export]
    public AudioStream AcceptSfx;

    [Export]
    public AudioStream CancelSfx;

    private Dictionary<GameScenes, AudioStream> sceneMusic;
    private AudioStreamPlayer music;
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

    public void SetMusic(GameScenes scene)
    {
        AudioStream stream = this.sceneMusic[scene];

        if (stream == this.music.Stream)
            return;

        this.music.Stream = stream;
        this.music.Play();
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
