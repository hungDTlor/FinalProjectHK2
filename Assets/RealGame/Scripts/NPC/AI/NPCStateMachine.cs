using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCStateMachine 
{  
    public NPCState[] states;  
    public NPCAgent npcAgent;
    public NPCStateID npcCurrentState;

    public NPCStateMachine(NPCAgent npcAgent)
    {
        this.npcAgent = npcAgent;
        int numStates = System.Enum.GetNames(typeof(NPCStateID)).Length;
        states = new NPCState[numStates];
    }
    public void RegisterNPCState(NPCState state)
    {
        int index = (int)state.GetID();
        states[index] = state;
    }
    public NPCState GetNPCState(NPCStateID stateId)
    {
        int index = (int)stateId;
        return states[index];
    }
    public void Update()
    {
        GetNPCState(npcCurrentState)?.Update(npcAgent);
    }

    public void ChangeState(NPCStateID newState)
    {
        GetNPCState(npcCurrentState)?.Exit(npcAgent);
        npcCurrentState = newState;
        GetNPCState(npcCurrentState)?.Enter(npcAgent);
    }
}
