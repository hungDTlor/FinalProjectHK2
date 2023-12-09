using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCAgent : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public NPCStateMachine npcStateMachine;
    public NPCStateID initialState;
    public Transform centrePoint;
    public Animator animator;
    public Vector3 nextPos;
    public Vector3 aimPos;
    public float aimTimer;
    public WeaponIK weaponIK;
    
    // Start is called before the first frame update
    void Start()
    {
        npcStateMachine = new NPCStateMachine(this);
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        weaponIK = GetComponent<WeaponIK>();
        npcStateMachine.RegisterNPCState(new NPCIdleState());
        npcStateMachine.RegisterNPCState(new NPCPatrolState());
        npcStateMachine.RegisterNPCState(new NPCAimState());
        npcStateMachine.ChangeState(initialState);
    }

    // Update is called once per frame
    void Update()
    {
        npcStateMachine.Update();
    }
}
