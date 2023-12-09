using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPoint : MonoBehaviour
{
    [SerializeField]float maxHP ;
    [SerializeField] public GameObject player;

    private float health;
    public float dmg=0.1f;

    private void Awake()
    {
        health = maxHP;
    }

    private void Update()
    {
        if (health<=0)
        {
            Destroy(player);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            health -= dmg;
            Debug.Log("Health: " + health);
        }
        
        
    }

    

}
