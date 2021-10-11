using Godot;
using System;

public class PlayerStateFactory {
    public PlayerState New(State state)
    {
        PlayerState newState = null;

        switch (state)
        {
            case State.RUNNING:
                newState = new RunningState();
                break;

            case State.MAIN_ACTION:
                newState = new MainActionState();
                break;

            case State.SECONDARY_ACTION:
                newState = new SecondaryActionState();
                break;
                
            case State.FALLING:
                newState = new MainActionState();
                ((MainActionState) newState).jumping = false;
                ((MainActionState) newState).canJump = true;
                break;
        }

        return newState;
    }
}