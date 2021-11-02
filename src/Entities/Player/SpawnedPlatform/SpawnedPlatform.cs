using Godot;
using System;

/// <summary>
///     Platforms that the player can spawn with the spawn platforms secondary action.
///     They destroy themselves after half a second.
/// </summary>
public class SpawnedPlatform : StaticBody2D
{
    /// <summary>
    ///     The timer for destruction.
    /// </summary>
    private Timer destroyTimer;

    public override void _Ready()
    {
        this.Scale *= new Vector2(1.5f, 1);
        this.destroyTimer = this.GetNode<Timer>("DestroyTimer");
        this.destroyTimer.Connect("timeout", this, nameof(this.OnDestroyTimerTimeout));
    }

    public void OnDestroyTimerTimeout()
    {
        this.QueueFree();
    }
}
