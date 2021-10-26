using Godot;
using System;

public abstract class MainAction: PlayerState {
    protected bool onActionPad = false;
    public bool performingAction = false;
    public bool canUseActionPad = true;
    protected bool blocked = false;

    public override void _Init()
    {
        this.player.jumpObjectCollisionCheck.Connect("area_entered", this, nameof(this.OnMainActionObjectCollisionCheckAreaEntered));
        this.player.jumpObjectCollisionCheck.Connect("area_exited", this, nameof(this.OnMainActionObjectCollisionCheckAreaExited));
        
        this.player.mainActionTimer.Connect("timeout", this, nameof(this.OnMainActionTimerTimeout));
        this.player.mainActionTimer.WaitTime = this.player.maxJumpTime;
        this.player.mainActionTimer.Stop();
    }

    public override void _StatePhysicsProcess(float delta)
    {
        if (Input.IsActionJustReleased("action_main"))
        {
            this._ActionReleased();
        }

        if (Input.IsActionPressed("action_main") && !(this.blocked || this.player.blocked)) {
            if (this.player.persistentState is OnGroundState)
            {
                this._ActionOnGround();
            }

            if (this.player.persistentState is OnAirState)
            {
                this._ActionOnAir();
            }
        }

        if (this.performingAction)
        {
            this._ActionProcess(delta);
        }
    }

    public virtual void _ActionOnGround()
    {
        this.performingAction = true;
        this.player.mainActionTimer.Start();
        this.canUseActionPad = false;
        this.player.linearVelocity.y = 0;
    }

    public virtual void _ActionOnAir()
    {
        if (this.onActionPad && this.canUseActionPad) {
            this.performingAction = true;
            this.onActionPad = false;
            this.player.mainActionTimer.Start();
            this.canUseActionPad = false;
            this.player.linearVelocity.y = 0;
        }
    }

    public virtual void _ActionReleased()
    {
        this.canUseActionPad = true;
    }

    public abstract void _ActionProcess(float delta);

    public void Block()
    {
        this.blocked = true;
    }

    public void UnBlock()
    {
        this.blocked = false;
    }

    public virtual void OnMainActionTimerTimeout()
    {
        this.performingAction = false;
    }


    public virtual void OnMainActionObjectCollisionCheckAreaEntered(Area2D area)
    {
        if (area.IsInGroup("jump"))
        {
            this.onActionPad = true;
        }

        if (area.IsInGroup("jump_auto"))
        {
            this.performingAction = true;
            this.player.mainActionTimer.Start();
            this.player.linearVelocity.y = 0;
        }
    }

    public virtual void OnMainActionObjectCollisionCheckAreaExited(Area2D area)
    {
        if (area.IsInGroup("jump"))
        {
            this.onActionPad = false;
        }
    }
}