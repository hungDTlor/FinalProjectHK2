using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieMovement : MonoBehaviour
{

    public float walkSpeed = 2f;
    public float runSpeed = 3.7f;


    [SerializeField] private NavMeshAgent agent;

    [SerializeField] private Transform player;

    [HideInInspector]public Transform target;

    [SerializeField] LayerMask playerMask;

    [SerializeField] Animator zombieAnimator;

    private EnemyVision enemyVision;
    private EnemySniff enemySniff;
    
    private EnemyAttacking enemyAttacking;

    public EnemyMovementState currentState;

    private void Awake()
    {
        enemySniff=GetComponent<EnemySniff>();
        enemyVision=GetComponent<EnemyVision>();
        enemyAttacking=GetComponent<EnemyAttacking>(); 
        zombieAnimator=GetComponent<Animator>();
        currentState=GetComponent<EnemyMovementState>();

        currentState = EnemyMovementState.Idle;
        

    }
    // Start is called before the first frame update
    void Start()
    {
        
        

    }

    // Update is called once per frame
    void Update()
    {

        switch (currentState)
        {
            case EnemyMovementState.Idle: 
                {
                    ZombieIdle(); 
                    break; 
                }
            case EnemyMovementState.Patrolling: 
                { 
                    break; 
                }

            case EnemyMovementState.Chasing: 
                {
                    if(enemyVision.canSeePlayer==true)
                    {
                        ZombieChasing();
                    }
                    break; 
                }
            case EnemyMovementState.Attacking: 
                { 
                    break; 
                }
            case EnemyMovementState.Died: 
                { 
                    break; 
                }

        }

    }

    public void ZombieMove()
    {
        
        
    }

    public void ZombieIdle()
    {
        
        
        
    }

    public void ZombiePatrolling()
    {
        
        target.position = player.position;
        agent.speed = walkSpeed;

    }

    public void ZombieChasing()
    {
        Debug.Log("Chasing");
        /*
            zombieAnimator.SetBool("isChasing", true);
            target.position = player.position;
            zombieAnimator.SetFloat("Speed", runSpeed);
            agent.speed = runSpeed;
        */
        
    }

    public void ZombieAttacking()
    {
        
    }

    public void ZombieDeath()
    {
        
    }

    public void SwitchEnemyState(EnemyMovementState newState)
    {
        /*
          public enum EnemyMovementState
            {
                Idle, Patrolling, Chasing, Died, Attacking
            }
        */

        switch (currentState)
        {
            case EnemyMovementState.Idle: { break; }
            case EnemyMovementState.Patrolling: { break; }

            case EnemyMovementState.Chasing: { break; }
            case EnemyMovementState.Attacking: { break; }
            case EnemyMovementState.Died: { break; }

        }

        switch (newState)
        {
            case EnemyMovementState.Idle: { break; }
            case EnemyMovementState.Patrolling: { break; }

            case EnemyMovementState.Chasing: { break; }
            case EnemyMovementState.Attacking: { break; }
            case EnemyMovementState.Died: { break; }
        }

        currentState = newState;

    }
}
