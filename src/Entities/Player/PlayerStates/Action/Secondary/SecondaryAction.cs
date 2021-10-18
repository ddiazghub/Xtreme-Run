using Godot;
using System;

public abstract class SecondaryAction: PlayerState {
    protected bool blocked = false;
    public bool performingAction = false;

    public override void _Init()
    {
        this.player.secondaryActionTimer.Stop();
        this.player.secondaryActionTimer.Connect("timeout", this, nameof(this.OnSecondaryActionTimerTimeout));
    }

    public override void _StatePhysicsProcess(float delta)
    {
        if (Input.IsActionJustReleased("action_secondary") && this.blocked) {
            this._ActionReleased();
        }

        if (Input.IsActionPressed("action_secondary") && !(this.blocked || this.player.blocked))
        {
            if (this.player.persistentState is OnGroundState) {
                this._ActionOnGround();
                this.performingAction = true;
                this.player.secondaryActionTimer.Start();
                this.blocked = true;
            }

            if (this.player.persistentState is OnAirState) {
                this._ActionOnAir();
            }
        }
    }

    public abstract void _ActionOnGround();

    public abstract void _ActionOnAir();

    public virtual void _ActionReleased()
    {
        this.blocked = false;
    }

    public void Block()
    {
        this.blocked = true;
    }

    public void UnBlock()
    {
        this.blocked = false;
    }

    public virtual void OnSecondaryActionTimerTimeout()
    {
        this.player.animation.Play("running");
        this.player.mainAction.UnBlock();
        this.performingAction = false;
        this.player.secondaryActionTimer.Stop();
    }
}
/*
public class SecondaryActionState: PlayerState {


    public override void _Init()
    {
        this.animation.Play("sliding");
        
        this.frontCollisionCheck.Connect("body_entered", this, nameof(this.OnFrontCollisionCheckBodyEntered));
        this.jumpObjectCollisionCheck.Connect("area_entered", this, nameof(this.OnJumpObjectCollisionCheckAreaEntered));

        this.SetHitbox(PlayerPersistentState.SECONDARY_ACTION);

        this.slideTimer.Connect("timeout", this, nameof(this.OnSlideTimerTimeout));
        this.slideTimer.Start();
    }

    public override void _StatePhysicsProcess(float delta)
    {
        if (this.right)
            this.player.linearVelocity.x = this.movementSpeed;
        else
            this.player.linearVelocity.x = -this.movementSpeed;
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
            this._onJumpObject = true;
        }

        if (area.IsInGroup("jump_auto"))
        {
            this.player.ChangePersistentState(PlayerPersistentState.ON_AIR);
        }
    }

    public void OnSlideTimerTimeout()
    {
        if (this.player.IsOnFloor())
            this.player.ChangePersistentState(PlayerPersistentState.ON_GROUND);
        else
            this.player.ChangePersistentState(PlayerPersistentState.ON_AIR);
    }

    public override string GetState()
    {
        return "Sliding";
    }
}
*/