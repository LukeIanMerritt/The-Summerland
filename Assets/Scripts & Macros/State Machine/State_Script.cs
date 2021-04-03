using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State_Script
{
    protected StatsController_Script npcInfo;
    protected StateMachine_Script stateMachine;

    protected State_Script(StatsController_Script _npcInfo, StateMachine_Script _stateMachine)
    {
        this.npcInfo = _npcInfo;
        this.stateMachine = _stateMachine;
    }

    public virtual void Enter()
    {

    }

    public virtual void HandleInput()
    {

    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {

    }

    public virtual void Exit()
    {

    }
}
