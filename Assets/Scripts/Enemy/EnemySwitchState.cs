using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySwitchState : MonoBehaviour
{
    EnemyMovementState enemyMovementState;
    EnemyMovement eMovement;
    EnemyVision eVision;

    private void Awake()
    {
        //enemyMovementState = GetComponent<EnemyMovementState>();
        eMovement = GetComponent<EnemyMovement>();
        eVision = GetComponent<EnemyVision>();
    }
    // Start is called before the first frame update
    void Start()
    {
        SetEnemyState(EnemyMovementState.Patrolling);
    }

    // Update is called once per frame
    void Update()
    {
        CheckEnemyState();
    }

    public void CheckEnemyState()
    {
        switch (enemyMovementState) 
        {
            case (EnemyMovementState.Patrolling):
                {
                   
                    eMovement.EPatrolling();
                    eMovement.EMovement();
                    if (eVision.canSeePlayer == true)
                    {
                        SetEnemyState(EnemyMovementState.Chasing);
                    }
                    break;
                }
            case (EnemyMovementState.Chasing):
                {
                    eMovement.TargetPlayer();
                    eMovement.EMovement();
                    if (!eVision.canSeePlayer)
                    {
                        //eMovement.ResetDestination();
                        
                        SetEnemyState(EnemyMovementState.Patrolling);
                    }
                    
                    break;

                }
            case (EnemyMovementState.Attacking):
                {
                    break; 

                }
            case (EnemyMovementState.Died):
                {
                    break;
                }

        }


    }

    public void SetEnemyState(EnemyMovementState _enemyMovementState)
    {
         enemyMovementState = _enemyMovementState;
    }


}
