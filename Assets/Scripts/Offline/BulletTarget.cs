using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class BulletTarget : MonoBehaviour
{
    //EnemyTakeDamage

    public Animator animator;
    public GameObject enemy;

    public GameObject player;
    public float turnSpeed = 15f;


    public Transform targetPlayerHit;
    


    //
    [SerializeField] float maxHp = 10;
    private float currentHp;

    public bool getHit = false;
    private void Awake()
    {
        currentHp = maxHp;
    }
    private void Update()
    {
        
        if (currentHp <= 0)
        {
            animator.SetBool("isDeath", true);
            animator.SetInteger("deathIndex", Random.Range(0, 2));
            StartCoroutine(DestroyEnemy());
        }

       

        

        

    }

    IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(20f);
        Debug.Log("Destroy");
        Destroy(enemy.gameObject);
    }
    public void GetHit(float dmg)
    {
        currentHp -= dmg;
        Debug.Log(enemy.name + ": " + currentHp);
        targetPlayerHit = player.transform;
            
        
        
        animator.SetTrigger("isGethit");

        getHit = true;
    }

    IEnumerator RotateToPlayer()
    {
        
        yield return new WaitForSeconds(0f);
        var towardsPlayer = targetPlayerHit.position - transform.position;
        
        transform.rotation = Quaternion.RotateTowards(
            transform.rotation,
            Quaternion.LookRotation(towardsPlayer),
             turnSpeed
        );
        
    }

    private void FixedUpdate()
    {
        if (getHit)
        {
            StartCoroutine(RotateToPlayer());
            StartCoroutine(StopRotate());
        }
    }

    IEnumerator StopRotate()
    {
        yield return new WaitForSeconds(3.3f);
        getHit = false;
        targetPlayerHit = null;
    }



}
