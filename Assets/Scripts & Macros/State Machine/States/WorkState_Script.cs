using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WorkState_Script : State_Script
{
    NavMeshAgent agent;

    public WorkState_Script(StatsController_Script npcInfo, StateMachine_Script stateMachine) : base(npcInfo, stateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Work State");
        agent = npcInfo.gameObject.GetComponent<NavMeshAgent>();

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
        agent.SetDestination(npcInfo.workItem.transform.position);
    }
}
