using Godot;
using System;

public class PlayerStateFactory {
    public PlayerState New(PersistentState state)
    {
        PlayerState newState = null;

        switch (state)
        {
            case PersistentState.ON_GROUND:
                newState = new OnGroundState();
                break;

            case PersistentState.ON_AIR:
                newState = new MainActionState();
                break;

            case PersistentState.SECONDARY_ACTION:
                newState = new SecondaryActionState();
                break;
                
            case PersistentState.FALLING:
                newState = new MainActionState();
                ((MainActionState) newState).jumping = false;
                ((MainActionState) newState).canJump = true;
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
                newState = new OnGroundState();
                break;

            case PlayerMainAction.JETPACK:
                newState = new MainActionState();
                break;

            case PlayerMainAction.GLIDE:
                newState = new SecondaryActionState();
                break;
                
            case PlayerMainAction.TELEPORT:
                newState = new MainActionState();
                ((MainActionState) newState).jumping = false;
                ((MainActionState) newState).canJump = true;
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
                newState = new MainActionState();
                break;

            case PlayerSecondaryAction.TELEPORT_AND_SWITCH_GRAVITY:
                newState = new SecondaryActionState();
                break;
                
            case PlayerSecondaryAction.SPAWN_BLOCKS:
                newState = new MainActionState();
                ((MainActionState) newState).jumping = false;
                ((MainActionState) newState).canJump = true;
                break;
        }

        return newState;
    }
}