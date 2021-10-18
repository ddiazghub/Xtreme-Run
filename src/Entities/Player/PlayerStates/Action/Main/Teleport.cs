using Godot;
using System;

public class Teleport: MainAction {
    public int TELEPORT_DISTANCE = 256;
    public override void _Init()
    {
        if (this.player.invertedGravity)
        {
            this.TELEPORT_DISTANCE = -this.TELEPORT_DISTANCE; 
        }

        this.player.jumpForce = this.player.DEFAULT_JUMPFORCE;
        this.player.maxJumpTime = this.player.DEFAULT_MAX_JUMP_TIME;
        this.player.maxFallSpeed = this.player.DEFAULT_JUMPFORCE;
        this.player.gravity = this.player.DEFAULT_GRAVITY;
    
        base._Init();
    }

    public override void _ActionOnGround()
    {
        if (!this.performingAction)
        {
            this.player.Position = new Vector2(this.player.Position.x, this.player.Position.y - this.TELEPORT_DISTANCE);
            this.performingAction = true;
        }
    }

    public override void _ActionOnAir()
    {
        if (this.onActionPad && this.canUseActionPad && !this.performingAction) {
            this.player.linearVelocity.y = 3000;
            this.player.Position = new Vector2(this.player.Position.x, this.player.Position.y - this.TELEPORT_DISTANCE);
            this.performingAction = true;
            this.onActionPad = false;
            this.canUseActionPad = false;
        }
    }

    public override void _ActionReleased()
    {
        this.performingAction = false;
    }
    public override void _ActionProcess(float delta)
    {

    }

    public override void OnMainActionObjectCollisionCheckAreaEntered(Area2D area)
    {
        if (area.IsInGroup("jump"))
        {
            this.onActionPad = true;
        }

        if (area.IsInGroup("jump_auto"))
        {
            this.player.linearVelocity.y = 3000;
            this.player.Position = new Vector2(this.player.Position.x, this.player.Position.y - this.TELEPORT_DISTANCE);
        }
    }

    public override void OnMainActionTimerTimeout()
    {
    }
}