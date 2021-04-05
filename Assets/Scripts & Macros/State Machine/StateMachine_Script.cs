using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine_Script
{
    public State_Script CurrentState { get; private set; }
    
    public void Initialize(State_Script startingState)
    {
        CurrentState = startingState;
        startingState.Enter();
    }

    public void ChangeState(State_Script newState)
    {
        CurrentState.Exit();

        CurrentState = newState;
        newState.Enter();
    }
}
