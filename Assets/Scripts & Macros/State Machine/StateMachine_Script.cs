using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine_Script : MonoBehaviour
{
    public State_Script currentState { get; private set; }
    
    public void Initialize(State_Script startingState)
    {
        currentState = startingState;
        startingState.Enter();
    }

    public void ChangeState(State_Script newState)
    {
        currentState.Exit();

        currentState = newState;
        newState.Enter();
    }
}
