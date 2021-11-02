using System;
using Godot;

/// <summary>
///     Class that contains the base structure for a state that the player can have.
/// </summary>
public abstract class PlayerState: Node2D {
    
    /// <summary>
    ///     The player that owns the current state.
    /// </summary>
    protected Player Player { get; set; }

    /// <summary>
    ///     Setups the state and initializes it.
    /// </summary>
    public void Setup()
    {
        this.Player = this.GetParent<Player>();

        this._Init();
    }

    /// <summary>
    ///     The physics process that will be called each frame for the state.
    /// </summary>
    /// <param name="delta">Time since the last frame.</param>
    public abstract void _StatePhysicsProcess(float delta);

    /// <summary>
    ///     Setups the state and initializes it.
    /// </summary>
    public abstract void _Init();
}