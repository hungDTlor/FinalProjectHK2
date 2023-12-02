using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager: MonoBehaviour
{

    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;

    private void Awake()
    {
        //enemyPrefabs=GetComponent<>
    }
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemies();
    }

    private void OnEnable()
    {
        

    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemies()
    {
        int randomPoint = Mathf.RoundToInt(Random.RandomRange(0, spawnPoints.Length - 1));
        Instantiate(enemyPrefabs[0], spawnPoints[randomPoint].transform.position, Quaternion.identity);
    }
}
