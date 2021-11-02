using Godot;
using System;

/// <summary>
///     Main action that allows the player to teleport a small distance above them.
/// </summary>
public class Teleport: MainAction {
    
    /// <summary>
    ///     Default teleport distance.
    /// </summary>
    public int TELEPORT_DISTANCE = 256;
    public override void _Init()
    {
        if (this.Player.InvertedGravity)
        {
            this.TELEPORT_DISTANCE = -this.TELEPORT_DISTANCE; 
        }

        this.Player.JumpForce = this.Player.DEFAULT_JUMPFORCE;
        this.Player.MaxJumpTime = this.Player.DEFAULT_MAX_JUMP_TIME;
        this.Player.MaxFallSpeed = this.Player.DEFAULT_JUMPFORCE;
        this.Player.Gravity = this.Player.DEFAULT_GRAVITY;
    
        base._Init();
    }

    public override void _ActionOnGround()
    {
        if (!this.PerformingAction)
        {
            this.Player.Position = new Vector2(this.Player.Position.x, this.Player.Position.y - this.TELEPORT_DISTANCE);
            this.PerformingAction = true;
        }
    }

    public override void _ActionOnAir()
    {
        if (this.OnActionPad && this.CanUseActionPad && !this.PerformingAction) {
            this.Player.linearVelocity.y = 3000;
            this.Player.Position = new Vector2(this.Player.Position.x, this.Player.Position.y - this.TELEPORT_DISTANCE);
            this.PerformingAction = true;
            this.OnActionPad = false;
            this.CanUseActionPad = false;
        }
    }

    public override void _ActionReleased()
    {
        this.PerformingAction = false;
    }
    public override void _ActionProcess(float delta)
    {

    }

    public override void OnMainActionObjectCollisionCheckAreaEntered(Area2D area)
    {
        if (area.IsInGroup("jump"))
        {
            this.OnActionPad = true;
        }

        if (area.IsInGroup("jump_auto"))
        {
            this.Player.linearVelocity.y = 3000;
            this.Player.Position = new Vector2(this.Player.Position.x, this.Player.Position.y - this.TELEPORT_DISTANCE);
        }
    }

    public override void OnMainActionTimerTimeout()
    {
    }
}