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
        this.player.mainActionTimer.Start();
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
    }

    public virtual void _ActionOnAir()
    {
        if (this.onActionPad && this.canUseActionPad) {
            this.performingAction = true;
            this.onActionPad = false;
            this.player.mainActionTimer.Start();
            this.canUseActionPad = false;
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
/*
public class MainActionState: PlayerState {
    private bool onJumpPad = false;
    public bool jumping = true;
    public bool canJump = false;


    public override void _Init()
    {
        this.animation.Play("running");
        this.jumpObjectCollisionCheck.Connect("area_entered", this, nameof(this.OnJumpObjectCollisionCheckAreaEntered));
        this.jumpObjectCollisionCheck.Connect("area_exited", this, nameof(this.OnJumpObjectCollisionCheckAreaExited));
        this.frontCollisionCheck.Connect("body_entered", this, nameof(this.OnFrontCollisionCheckBodyEntered));
        this.groundCollisionCheck.Connect("body_entered", this, nameof(this.OnGroundCollisionCheckBodyEntered));

        this.SetHitbox(PlayerPersistentState.ON_AIR);
        
        this.jumpTimer.Connect("timeout", this, nameof(this.OnJumpTimerTimeout));
        this.jumpTimer.WaitTime = this.maxJumpTime;
        this.jumpTimer.Start();

        this.player.linearVelocity.y = 5000;
    }

    public override void _StatePhysicsProcess(float delta)
    {
        if (Input.IsActionJustReleased("action_main")) {
            this.canJump = true;
        }

        if (Input.IsActionPressed("action_main") && this.onJumpPad && this.canJump)
        {
            this.onJumpPad = false;
            this.jumping = true;
            this.jumpTimer.Start();
            this.canJump = false;
        }

        if (Input.IsActionPressed("action_secondary"))
        {
            this.jumping = false;
            this.player.linearVelocity.y = 100000;
        }


        if (this.jumping)
        {
            this.player.linearVelocity.y -= this.jumpForce;
        }

        if (this.right)
            this.player.linearVelocity.x = this.movementSpeed;
        else
            this.player.linearVelocity.x = -this.movementSpeed;
        
        if (this.player.linearVelocity.y > this.topFallSpeed)
            this.player.linearVelocity.y = this.topFallSpeed;

        if (this.player.linearVelocity.y < -this.jumpForce)
            this.player.linearVelocity.y = -this.jumpForce;
    }

    public void OnJumpTimerTimeout()
    {
        this.jumping = false;
    }

    public void OnFrontCollisionCheckBodyEntered(Node body)
    {
        if (body.IsInGroup("solid") || body.IsInGroup("hazard"))
        {
            this.player.EmitSignal("Dead");
        }
    }

    public void OnJumpObjectCollisionCheckAreaEntered(Area2D area)
    {
        if (area.IsInGroup("jump"))
        {
            this.onJumpPad = true;
        }

        if (area.IsInGroup("jump_auto"))
        {
            this.jumping = true;
            this.jumpTimer.Start();
        }
    }

    public void OnJumpObjectCollisionCheckAreaExited(Area2D area)
    {
        if (area.IsInGroup("jump"))
        {
            this.onJumpPad = false;
        }
    }

    public void OnGroundCollisionCheckBodyEntered(Node body)
    {
        if (body.IsInGroup("hazard")) {
            this.player.EmitSignal("Dead");
        }

        if (!this.jumping)
        {
            this.player.ChangePersistentState(PlayerPersistentState.ON_GROUND);
        }
    }
}
*/