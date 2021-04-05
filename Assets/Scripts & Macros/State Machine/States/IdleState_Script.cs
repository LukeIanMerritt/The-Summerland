using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState_Script : State_Script
{
    public IdleState_Script(StatsController_Script npcInfo, StateMachine_Script stateMachine) : base(npcInfo, stateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Idle State");
        stateMachine.ChangeState(npcInfo.wandering);

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void HandleInput()
    {
        base.HandleInput();
        Debug.Log("Handing Input");
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        Debug.Log("Idle State");
    }
}
