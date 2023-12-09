using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTarget : MonoBehaviour
{
    //EnemyTakeDamage

    public Animator animator;
    public GameObject enemy;


    //
    [SerializeField] float maxHp = 10;
    private float currentHp;
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

        animator.SetTrigger("isGethit");
    }
    
}
