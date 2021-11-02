using Godot;
using System;

/// <summary>
///     Secondary action that allows the player to spawn platforms while on air.
/// </summary>
public class SpawnPlatforms: SecondaryAction {

    /// <summary>
    ///     The platforms that can be spawned.
    /// </summary>
    [Export] public PackedScene PlatformScene = ResourceLoader.Load<PackedScene>("res://src/Entities/Player/SpawnedPlatform/SpawnedPlatform.tscn");
    
    public override void _Init()
    {
        base._Init();
        this.Player.secondaryActionTimer.WaitTime = 1f;
    }

    public override void _ActionOnGround()
    {
    }
    

    public override void _ActionOnAir()
    {
        SpawnedPlatform platform = this.PlatformScene.Instance<SpawnedPlatform>();
        
        int verticalSpace = 30;

        if (Player.InvertedGravity)
        {
            platform.Position = new Vector2( this.Player.Position.x + 1.2f * ((RectangleShape2D) platform.GetNode<CollisionShape2D>("CollisionShape2D").Shape).Extents.x, this.Player.Position.y - (((CapsuleShape2D) this.Player.runningCollision.Shape).Height / 2 + verticalSpace));
        }
        else
        {
            platform.Position = new Vector2( this.Player.Position.x + 1.2f * ((RectangleShape2D) platform.GetNode<CollisionShape2D>("CollisionShape2D").Shape).Extents.x, this.Player.Position.y + (((CapsuleShape2D) this.Player.runningCollision.Shape).Height / 2 + verticalSpace));
        }
        
        this.Player.GetParent().AddChild(platform);
        this.Blocked = true;
    }

    public override void _ActionReleased()
    {
        base._ActionReleased();
    }
    public override void OnSecondaryActionTimerTimeout()
    {
    }
}