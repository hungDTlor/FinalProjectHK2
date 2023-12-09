using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIIdleState : AIState
{

    float range = 4f;
    float maxTimer = 4.5f;
    float timer;
    float getPosTimer = 0.5f;
    bool isNextPos;
    Vector3 minVec = new Vector3(1.5f, 1.5f, 1.5f);
    Vector3 maxVec = new Vector3(4, 4, 4);
    Vector3 point;
    public AIStateID GetID()
    {
        return AIStateID.Idle;
    }
    public void Enter(AIAgent agent)
    {
        Debug.Log("Enter idle");
        //agent.animator.SetBool("isIdle", true);
        isNextPos = false;
        timer = maxTimer;
        getPosTimer = 0.25f;
        RandomPoint(agent.transform.position, range, out point);
    }
    public void Update(AIAgent agent)
    {
        timer -= Time.deltaTime;
        getPosTimer -= Time.deltaTime;
        if (timer <= 0 && isNextPos == true)
        {
            //agent.npcStateMachine.ChangeState(NPCStateID.Patrolling);
        }

        if (!isNextPos)
        {
            if (getPosTimer <= 0)
            {
                if ((point - agent.navMeshAgent.transform.position).magnitude < minVec.magnitude || (point - agent.navMeshAgent.transform.position).magnitude > maxVec.magnitude)
                {
                    RandomPoint(agent.transform.position, range, out point);
                    getPosTimer = 0.25f;
                }
                else
                {
                    agent.nextPos = point;
                    isNextPos = true;
                    Debug.DrawRay(agent.nextPos, Vector3.up, Color.blue, 1.0f);
                }
            }
        }
    }
    public void Exit(AIAgent agent)
    {
        //agent.animator.SetBool("isIdle", false);
    }
    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        Vector3 randompoint = center + Random.insideUnitSphere * range;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randompoint, out hit, 1.0f, NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }
        result = Vector3.zero;
        return false;
    }



}
