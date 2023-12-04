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

    public Transform target;

    [SerializeField] LayerMask playerMask;

    private Animator zombieAnimator;

    private EnemyVision enemyVision;
    private EnemySniff enemySniff;
    private EnemyMovementState enemyMovementState;
    private EnemyAttacking enemyAttacking;


    private void Awake()
    {
        enemySniff=GetComponent<EnemySniff>();
        enemyVision=GetComponent<EnemyVision>();
        enemyAttacking=GetComponent<EnemyAttacking>(); 
        zombieAnimator=GetComponent<Animator>();

    }
    // Start is called before the first frame update
    void Start()
    {
        
        

    }

    // Update is called once per frame
    void Update()
    {
        if (enemySniff.findPlayer== false && enemyVision.canSeePlayer==false)
        {

            zombieAnimator.SetBool("isPatrolling", false);
            ZombieIdle();
            Movement();
        }
        else if (enemySniff.findPlayer == true && enemyVision.canSeePlayer == false)
        {
            zombieAnimator.SetBool("isPatrolling", true);
            ZombiePatrolling();
            Movement();
        }
    }

    public void Movement()
    {
        if (Vector3.Distance(target.position, transform.position) > 1f)
        {
            agent.SetDestination(target.position);
            zombieAnimator.SetFloat("Speed", 0.2f);
        }

        else
        {
            agent.SetDestination(transform.position);
            zombieAnimator.SetFloat("Speed", 0f);


        }
    }

    public void ZombieIdle()
    {
        target = transform;
        
        zombieAnimator.SetBool("isPatrolling", false);
        
        agent.speed = 0f;

        zombieAnimator.SetFloat("Speed", 0f);
    }

    public void ZombiePatrolling()
    {
        
        target.position = player.position;
        agent.speed = walkSpeed;

    }

    public void ZombieChasing()
    {
        target.position = player.position;
    }

    public void ZombieAttacking()
    {
        target.position = player.position;
    }

    public void ZombieDeath()
    {
        
    }
}
