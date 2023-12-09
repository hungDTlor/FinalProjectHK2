using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEvent : MonoBehaviour
{

    [SerializeField] public GameObject hitPoint;
    [SerializeField] EnemyAttacking enemyAttacking;
    public void PlayHitPoint()
    {

        //hitPoint.SetActive(true);

    }




   

    public void StopHitPoint()
    {

        //attackAnimator.SetBool("Attack", false);
        //hitPoint.SetActive(false);




    }
}
