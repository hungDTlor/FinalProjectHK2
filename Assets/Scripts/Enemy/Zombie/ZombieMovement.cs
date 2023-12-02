using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieMovement : MonoBehaviour
{

    [SerializeField] private float speed = 2f;

    [SerializeField] private NavMeshAgent agent;

    [SerializeField] private Transform player;

    private Transform target;

    [SerializeField] LayerMask playerMask;

    [SerializeField] private Animator zombieAnimator;

    private EnemyVision enemyVision;
    private EnemySniff enemySniff;


    private void Awake()
    {
        enemySniff=GetComponent<EnemySniff>();
        enemyVision=GetComponent<EnemyVision>();
        zombieAnimator=GetComponent<Animator>();

    }
    // Start is called before the first frame update
    void Start()
    {
        agent.speed = speed;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Movement()
    {
        if (Vector3.Distance(target.position, transform.position) > 1.5f)
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

    public void ZIdle()
    {
        target = transform;
        zombieAnimator.SetFloat("Speed", 0f);
    }

    public void ZPattrolling()
    {
        if (enemySniff)
        {


            target.position = player.position;

        }
    }
}
