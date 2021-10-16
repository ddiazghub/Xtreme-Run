using Godot;
using System;

public class SpawnedPlatform : StaticBody2D
{
    private Timer destroyTimer;

    public override void _Ready()
    {
        this.destroyTimer = this.GetNode<Timer>("DestroyTimer");
        this.destroyTimer.Connect("timeout", this, nameof(this.OnDestroyTimerTimeout));
    }

    public void OnDestroyTimerTimeout()
    {
        this.QueueFree();
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
