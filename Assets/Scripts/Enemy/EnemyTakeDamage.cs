using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTakeDamage : MonoBehaviour
{


    [SerializeField] Animator animator;

    [SerializeField] float maxHp = 10;
    private float currentHp;
    private void Awake()
    {
        currentHp = maxHp;
    }
    private void Update()
    {
        if (currentHp <= 0) Destroy(gameObject);
    }
    public void GetHit(float dmg)
    {
        currentHp -= dmg;
    }

}
