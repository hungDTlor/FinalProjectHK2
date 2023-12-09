using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDetection : MonoBehaviour ,IHear
{
    NPCAgent agent;
    Collider collider;
    public void ReponseToSound(Sound sound)
    {
        if(agent.npcStateMachine.npcCurrentState != NPCStateID.Aiming)
        {
            Debug.Log("I hear a sound");
            agent.aimPos = sound.pos;
            agent.npcStateMachine.ChangeState(NPCStateID.Aiming);
        }
        else
        {
            agent.aimTimer += 3f;
            agent.aimPos = sound.pos;
            
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponentInParent<NPCAgent>();
        collider = GetComponent<Collider>();
    }

   

}
