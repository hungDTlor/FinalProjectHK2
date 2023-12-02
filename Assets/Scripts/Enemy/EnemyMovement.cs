using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    public float speed = 2f;
    [SerializeField]
    public NavMeshAgent agent;
    [SerializeField]
    public List<Transform> destination;

    [SerializeField] public Transform player;

    public Transform target;

    [SerializeField] LayerMask playerMask;

    [SerializeField]
    private Animator enemyAnimator;
    private float distance ;
    

    private Transform cube;

    [SerializeField] GameObject moveZone;
    public EnemyVision enemyVision;
    public float minDistance;
    public int indexPosition = 0;

    
    private void Awake()
    {
        enemyVision = GetComponent<EnemyVision>();
        moveZone = GetComponent<GameObject>();
    }
    // Start is called before the first frame update
    void Start()
    {
        agent.speed = speed;
        target = destination[0];
        
    }

    // Update is called once per frame
    void Update()
    {

        


        

        /*
        if (Physics.CheckSphere(transform.position, 10, playerMask))
        {
            target = player;
        }
        else
        {
            target = cube;
        }
        */

        
        

    }

    /*
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.3f);
        Gizmos.DrawSphere(transform.position, 10);
    }
    */

    public void EMovement()
    {

        if (Vector3.Distance(target.position, transform.position) > 3f)
        {
            agent.SetDestination(target.position);
            enemyAnimator.SetFloat("Speed", 0.2f);
        }

        else
        {
            agent.SetDestination(transform.position);
            enemyAnimator.SetFloat("Speed", 0f);


        }
    }

    public void TargetPlayer()
    {
        target = player;
    }

    public void EPatrolling()
    {

        /*
        
        if (Vector3.Distance(target.position, transform.position) < 3f)
        {

            indexPosition++;
            target = destination[indexPosition];
            if (indexPosition == destination.Count - 1)
            {
                indexPosition = -1;
            }
        }
        */


    }


    IEnumerator EnemyMove()
    {
        yield return null;
    }

    

    public void ResetDestination()
    {
        minDistance = Vector3.Distance(transform.position, destination[0].position);

        for (int i = 0; i < destination.Count; i++)
        {
            if (Vector3.Distance(transform.position, destination[i].position) <= minDistance)
            {
                minDistance = Vector3.Distance(transform.position, destination[i].position);
                if (minDistance < Vector3.Distance(transform.position, destination[indexPosition].position))
                {
                    target = destination[i];
                    indexPosition = i;


                }
                else
                {
                    target = destination[indexPosition];
                }
            }

            

        }
        
    }


}
