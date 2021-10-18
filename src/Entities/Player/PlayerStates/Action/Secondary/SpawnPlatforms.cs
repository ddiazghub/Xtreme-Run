using Godot;
using System;

public class SpawnPlatforms: SecondaryAction {
    private PackedScene platformScene = ResourceLoader.Load<PackedScene>("res://src/Entities/Player/SpawnedPlatform/SpawnedPlatform.tscn");
    
    public override void _Init()
    {
        base._Init();
        this.player.secondaryActionTimer.WaitTime = 1f;
    }

    public override void _ActionOnGround()
    {
    }

    public override void _ActionOnAir()
    {
        SpawnedPlatform platform = this.platformScene.Instance<SpawnedPlatform>();
        
        int verticalSpace = this.player.linearVelocity.y > 667 || this.player.linearVelocity.y < -667 ? 30 : 128;
        if (player.invertedGravity)
            platform.Position = new Vector2( this.player.Position.x + 1.2f * ((RectangleShape2D) platform.GetNode<CollisionShape2D>("CollisionShape2D").Shape).Extents.x, this.player.Position.y - (((CapsuleShape2D) this.player.runningCollision.Shape).Height / 2 + verticalSpace));
        else
            platform.Position = new Vector2( this.player.Position.x + 1.2f * ((RectangleShape2D) platform.GetNode<CollisionShape2D>("CollisionShape2D").Shape).Extents.x, this.player.Position.y + (((CapsuleShape2D) this.player.runningCollision.Shape).Height / 2 + verticalSpace));
        
        this.player.GetParent().AddChild(platform);
        this.blocked = true;
    }

    public override void _ActionReleased()
    {
        base._ActionReleased();
    }
    public override void OnSecondaryActionTimerTimeout()
    {
    }
}