using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public EnemySpawner[] enemySpawnerArray;

    // Start is called before the first frame update
    void Start()
    {
        enemySpawnerArray = transform.GetComponentsInChildren<EnemySpawner>();
        //for(int i = 0; i < enemySpawnerArray.Length; i++)
        //{
        //    enemySpawnerArray[i].AddComponent<EnemySpawner>();
        //}
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        for(int i = 0; i < enemySpawnerArray.Length; i++)
        {
            enemySpawnerArray[i].SpawnEnemy();
        }
    }
}
