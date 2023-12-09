using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakeDamage : MonoBehaviour
{
    [SerializeField] float maxHP;
    [SerializeField] public GameObject player;

    private float health;
    public float dmg = 0.1f;

    private void Awake()
    {
        health = maxHP;
    }

    private void Update()
    {
        if (health <= 0)
        {
            Debug.Log("Died");
            //Destroy(player.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            health -= dmg;
            Debug.Log("Health: " + health);
        }


    }
}
