using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour 
{
    NPCAgent agent;
    Animator animator;
    public Collider soundDetect;
   

    private void Start()
    {
        soundDetect = GetComponent<Collider>();
        animator = GetComponent<Animator>();
        agent = GetComponent<NPCAgent>();
    }
    private void Update()
    {
        /*switch (agent.npcStateMachine.npcCurrentState)
        {
            
            case NPCStateID.Idle:
                {
                    animator.SetBool("isIdle", true);
                    animator.SetBool("isPatrol", false);
                    animator.SetBool("isAim", false);
                    break;
                }
                case NPCStateID.Patrolling:
                {
                    animator.SetBool("isIdle", false);
                    animator.SetBool("isPatrol", true);
                    animator.SetBool("isAim", false);
                    break;
                }
                case NPCStateID.Aiming:
                {
                    animator.SetBool("isIdle", false);
                    animator.SetBool("isPatrol", false);
                    animator.SetBool("isAim", true);
                    break;
                }

        }*/
        
    }
    

}
