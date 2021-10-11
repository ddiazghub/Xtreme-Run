using Godot;
using System;

public class PlayerStateFactory {
    public PlayerState New(PlayerPersistentState state)
    {
        PlayerState newState = null;

        switch (state)
        {
            case PlayerPersistentState.ON_GROUND:
                newState = new OnGroundState();
                break;

            case PlayerPersistentState.ON_AIR:
                newState = new OnAirState();
                break;
        }

        return newState;
    }

    public PlayerState New(PlayerMainAction state)
    {
        PlayerState newState = null;

        switch (state)
        {
            case PlayerMainAction.JUMP:
                newState = new Jump();
                break;

            case PlayerMainAction.JETPACK:
                newState = new Jump();
                break;

            case PlayerMainAction.GLIDE:
                newState = new SecondaryActionState();
                break;
                
            case PlayerMainAction.TELEPORT:
                newState = new Jump();
                break;
        }

        return newState;
    }

    public PlayerState New(PlayerSecondaryAction state)
    {
        PlayerState newState = null;

        switch (state)
        {
            case PlayerSecondaryAction.FASTFALL_AND_ROLL:
                newState = new OnGroundState();
                break;

            case PlayerSecondaryAction.SWITCH_GRAVITY:
                newState = new Jump();
                break;

            case PlayerSecondaryAction.TELEPORT_AND_SWITCH_GRAVITY:
                newState = new Jump();
                break;
                
            case PlayerSecondaryAction.SPAWN_BLOCKS:
                newState = new Jump();
                break;
        }

        return newState;
    }
}