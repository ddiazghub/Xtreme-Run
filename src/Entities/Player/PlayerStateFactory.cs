using Godot;
using System;

public class PlayerStateFactory {
    public PlayerState New(PlayerStates state)
    {
        PlayerState newState = null;

        switch (state)
        {
            case PlayerStates.RUNNING:
                newState = new RunningState();
                break;

            case PlayerStates.JUMPING:
                newState = new JumpingState();
                break;

            case PlayerStates.SLIDING:
                newState = new SlidingState();
                break;
                
            case PlayerStates.FALLING:
                newState = new JumpingState();
                ((JumpingState) newState).jumping = false;
                ((JumpingState) newState).canJump = true;
                break;
        }

        return newState;
    }
}