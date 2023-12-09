using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NPCStateID
{
    Idle,
    Patrolling,
    Aiming
}
public interface NPCState
{
    NPCStateID GetID();
    void Enter(NPCAgent agent);
    void Update(NPCAgent agent);
    void Exit(NPCAgent agent);



}
