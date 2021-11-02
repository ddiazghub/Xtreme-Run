using Godot;
using System;

/// <summary>
///     Class that represents an action the player can perform as secondary action.
/// </summary>
public abstract class SecondaryAction: PlayerState {

    /// <summary>
    ///     Checks if the current action is blocked/disabled.
    ///     If true, the action will not be performed on input events.
    /// </summary>
    public bool Blocked { get; set; } = false;

    public override void _Init()
    {
        this.Player.secondaryActionTimer.Stop();
        this.Player.secondaryActionTimer.Connect("timeout", this, nameof(this.OnSecondaryActionTimerTimeout));
    }

    public override void _StatePhysicsProcess(float delta)
    {
        if (Input.IsActionJustReleased("action_secondary") && this.Blocked) {
            this._ActionReleased();
        }

        if (Input.IsActionPressed("action_secondary") && !(this.Blocked || this.Player.Blocked))
        {
            if (this.Player.persistentState is OnGroundState) {
                this._ActionOnGround();
            }

            if (this.Player.persistentState is OnAirState) {
                this._ActionOnAir();
            }
        }
    }

    /// <summary>
    ///     The action that will be executed if the player inputs the action's keys and the player's persistent state is on ground.
    /// </summary>
    public virtual void _ActionOnGround()
    {
        this.Player.secondaryActionTimer.Start();
        this.Blocked = true;
    }
        
    /// <summary>
    ///     The action that will be executed if the player inputs the action's keys and the player's persistent state is on air.
    /// </summary>
    public abstract void _ActionOnAir();

    /// <summary>
    ///     The action that will be executed once the player stops pressing the action's input keyboard/mouse buttons.
    /// </summary>
    public virtual void _ActionReleased()
    {
        this.Blocked = false;
    }

    /// <summary>
    ///     Gets the given action's type as a string.
    ///     This is because the player animations corresponding to each action has these names.
    /// </summary>
    /// <param name="action">The enum value of the action.</param>
    /// <returns>A string depending on the action type.</returns>
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

    /// <summary>
    ///     Gets the given action's type as a string in spanish.
    ///     This is for displaying on the GUI.
    /// </summary>
    /// <param name="action">The enum value of the action</param>
    /// <returns>A string in spanish depending on the action type.</returns>
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

    public virtual void OnSecondaryActionTimerTimeout()
    {
        this.Player.animation.Play("running");
        this.Player.mainAction.Blocked = false;
        this.Player.secondaryActionTimer.Stop();
    }
}