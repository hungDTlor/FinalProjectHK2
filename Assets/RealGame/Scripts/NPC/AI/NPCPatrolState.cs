using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCPatrolState : NPCState
{
    
    
    public NPCStateID GetID()
    {
        return NPCStateID.Patrolling;
    }
    public void Enter(NPCAgent agent)
    {
        Debug.Log("Enter patrol");
        agent.animator.SetBool("isPatrol", true);
        agent.navMeshAgent.destination = agent.nextPos;

    }
    public void Update(NPCAgent agent)
    {
        if (!agent.enabled) return;
        if(agent.npcStateMachine.npcCurrentState == NPCStateID.Patrolling)
        {           
            if (agent.navMeshAgent.remainingDistance <= agent.navMeshAgent.stoppingDistance)
            {                
                agent.npcStateMachine.ChangeState(NPCStateID.Idle);
            }            
        }

    }
    public void Exit(NPCAgent agent)
    {
        agent.animator.SetBool("isPatrol", false);
    }

    


}
