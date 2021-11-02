using Godot;
using System;

public abstract class SecondaryAction: PlayerState {
    public bool blocked = false;

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
            }

            if (this.player.persistentState is OnAirState) {
                this._ActionOnAir();
            }
        }
    }

    public virtual void _ActionOnGround()
    {
        this.player.secondaryActionTimer.Start();
        this.blocked = true;
    }
        

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
        this.player.secondaryActionTimer.Stop();
    }

    
    public static string GetTypeAsString(PlayerSecondaryAction action)
    {
        switch (action)
        {
            case PlayerSecondaryAction.FASTFALL_AND_ROLL:
                return "roll";
            
            case PlayerSecondaryAction.SWITCH_GRAVITY:
                return "switchGravity";
            
            case PlayerSecondaryAction.TELEPORT_AND_SWITCH_GRAVITY:
                return "tpAndSwitchGravity";

            case PlayerSecondaryAction.SPAWN_PLATFORMS:
                return "spawnPlatforms";
            
            default:
                return "roll";
        }
    }

    public static string GetTypeAsStringEsp(PlayerSecondaryAction action)
    {
        switch (action)
        {
            case PlayerSecondaryAction.FASTFALL_AND_ROLL:
                return "Caer/Esquivar";
            
            case PlayerSecondaryAction.SWITCH_GRAVITY:
                return "Cambiar Gravedad";
            
            case PlayerSecondaryAction.TELEPORT_AND_SWITCH_GRAVITY:
                return "TP/Cambiar Gravedad";

            case PlayerSecondaryAction.SPAWN_PLATFORMS:
                return "Crear Plataformas";
            
            default:
                return "Caer/Esquivar";
        }
    }
}