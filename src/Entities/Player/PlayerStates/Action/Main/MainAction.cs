using Godot;
using System;

/// <summary>
///     Class that represents an action the player can perform as main action.
/// </summary>
public abstract class MainAction: PlayerState {

    /// <summary>
    ///     Emitted if the player performs a main action.
    /// </summary>
    [Signal]
    public delegate void Action();

    /// <summary>
    ///     True if the player is currently on a jump pad.
    /// </summary>
    protected bool OnActionPad { get; set; } = false;

    /// <summary>
    ///    True if the player is currently performing a main action.
    /// </summary>
    public bool PerformingAction { get;  set; } = false;

    /// <summary>
    ///     True if the player can use jump pads.
    /// </summary>
    public bool CanUseActionPad = true;

    /// <summary>
    ///     Checks if the current action is blocked/disabled.
    ///     If true, the action will not be performed on input events.
    /// </summary>
    public bool Blocked { get; set; } = false;

    public override void _Init()
    {
        this.Player.jumpObjectCollisionCheck.Connect("area_entered", this, nameof(this.OnMainActionObjectCollisionCheckAreaEntered));
        this.Player.jumpObjectCollisionCheck.Connect("area_exited", this, nameof(this.OnMainActionObjectCollisionCheckAreaExited));
        
        this.Player.mainActionTimer.Connect("timeout", this, nameof(this.OnMainActionTimerTimeout));
        this.Player.mainActionTimer.WaitTime = this.Player.MaxJumpTime;
        this.Player.mainActionTimer.Stop();
    }

    public override void _StatePhysicsProcess(float delta)
    {

        if (Input.IsActionJustReleased("action_main"))
        {
            this._ActionReleased();
        }

        if (Input.IsActionPressed("action_main") && !(this.Blocked || this.Player.Blocked)) {
            if (this.Player.PersistentState is OnGroundState)
            {
                this._ActionOnGround();
            }

            if (this.Player.PersistentState is OnAirState)
            {
                this._ActionOnAir();
            }
        }

        if (this.PerformingAction)
        {
            this._ActionProcess(delta);
        }
    }

    public virtual void _ActionOnGround()
    {
        this.EmitSignal("Action");
        this.PerformingAction = true;
        this.Player.mainActionTimer.Start();
        this.CanUseActionPad = false;
        this.Player.linearVelocity.y = 0;
    }

    public virtual void _ActionOnAir()
    {
        if (this.OnActionPad && this.CanUseActionPad) {
            this.PerformingAction = true;
            this.OnActionPad = false;
            this.Player.mainActionTimer.Start();
            this.CanUseActionPad = false;
            this.Player.linearVelocity.y = 0;
        }
    }

    public virtual void _ActionReleased()
    {
        this.CanUseActionPad = true;
    }

    /// <summary>
    ///     The process that will be executed each frame while the action is being performed.
    /// </summary>
    /// <param name="delta">Time since last frame.</param>
    public abstract void _ActionProcess(float delta);

    /// <summary>
    ///     Gets the given action's type as a string.
    ///     This is because the player animations corresponding to each action has these names.
    /// </summary>
    /// <param name="action">The enum value of the action.</param>
    /// <returns>A string depending on the action type.</returns>
    public static string GetTypeAsString(PlayerMainAction action)
    {
        switch (action)
        {
            case PlayerMainAction.JUMP:
                return "jump";
            
            case PlayerMainAction.JETPACK:
                return "jetpack";
            
            case PlayerMainAction.GLIDE:
                return "glide";

            case PlayerMainAction.TELEPORT:
                return "teleport";
            
            default:
                return "jump";
        }
    }

    /// <summary>
    ///     Gets the given action's type as a string in spanish.
    ///     This is for displaying on the GUI.
    /// </summary>
    /// <param name="action">The enum value of the action</param>
    /// <returns>A string in spanish depending on the action type.</returns>
    public static string GetTypeAsStringEsp(PlayerMainAction action)
    {
        switch (action)
        {
            case PlayerMainAction.JUMP:
                return "Salto";
            
            case PlayerMainAction.JETPACK:
                return "Jetpack";
            
            case PlayerMainAction.GLIDE:
                return "Planear";

            case PlayerMainAction.TELEPORT:
                return "Teleportación";
            
            default:
                return "Salto";
        }
    }

    public virtual void OnMainActionTimerTimeout()
    {
        this.PerformingAction = false;
    }


    public virtual void OnMainActionObjectCollisionCheckAreaEntered(Area2D area)
    {
        if (area.IsInGroup("jump"))
        {
            this.OnActionPad = true;
        }

        if (area.IsInGroup("jump_auto"))
        {
            this.PerformingAction = true;
            this.Player.mainActionTimer.Start();
            this.Player.linearVelocity.y = 0;
        }
    }

    public virtual void OnMainActionObjectCollisionCheckAreaExited(Area2D area)
    {
        if (area.IsInGroup("jump"))
        {
            this.OnActionPad = false;
        }
    }
}