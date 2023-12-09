using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAimState : NPCState
{
    
    
    public NPCStateID GetID()
    {
        return NPCStateID.Aiming;
    }
    public void Enter(NPCAgent agent)
    {
        Debug.Log("Enter aim state");
        agent.aimTimer = 4f;
        agent.weaponIK.AimAtTarget(agent.weaponIK.bone, agent.aimPos);
        agent.animator.SetBool("isAim", true);
        
    }
    public void Update(NPCAgent agent)
    {
        agent.aimTimer -= Time.deltaTime;
        if(agent.aimTimer > 0)
        {
            agent.weaponIK.AimAtTarget(agent.weaponIK.bone, agent.aimPos);
        }
        else
        {
            agent.npcStateMachine.ChangeState(NPCStateID.Idle);
        }
                

    }
    public void Exit(NPCAgent agent)
    {
        agent.animator.SetBool("isAim", false) ;
    }

    

   

   
}
