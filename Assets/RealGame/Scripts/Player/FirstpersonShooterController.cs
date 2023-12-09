using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FirstpersonShooterController : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private LayerMask aimLayerMask;
    [SerializeField] public float defaultFOV = 60f;
    [SerializeField] private Transform bulletSpawnPos;
    [SerializeField] private Transform bulletPrefab;
    [SerializeField] private GameObject gun;

    [SerializeField] private KeyCode reloadKey;

    private float maxHp = 100;
    private float currentHp;

    public static Action shootInput;
    public static Action reloadInput;
    public static Action ADSInput;
    
    void Start()
    {
        currentHp = maxHp;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        shootInput?.Invoke();
        if (Input.GetKeyDown(reloadKey))
        {
            reloadInput?.Invoke();
        }
        ADSInput?.Invoke();
    }

    public void maxHpIncrement(float hp)
    {
        maxHp += hp;
        currentHp = maxHp;
    }

    public void currentHpDecrement(float hp)
    {
        currentHp -= hp;
    }

    public void currentHpIncrement(float hp)
    {
        if(currentHp + hp > maxHp) currentHp = maxHp;
        else currentHp += hp;
    }

    void Die()
    {
        if (currentHp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
