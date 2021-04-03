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
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void HandleInput()
    {
        base.HandleInput();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
