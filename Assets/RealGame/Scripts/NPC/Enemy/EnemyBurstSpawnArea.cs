
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[RequireComponent(typeof(Collider))]
public class EnemyBurstSpawnArea : MonoBehaviour
{
    [SerializeField] Collider spawnCollider;

    [SerializeField] private EnemySpawner spawner;
    [SerializeField] private List<ScriptableObject> enemies = new List<ScriptableObject>();
    [SerializeField] private EnemySpawner.SpawnMethod spawnMethod = EnemySpawner.SpawnMethod.Random;
    [SerializeField] private int spawnCount = 10;
    [SerializeField] private float spawnDelay = 0.5f;
    //private SpawnArea spawnArea;
    private Bounds bounds;
    private Coroutine spawnCoroutine;
    private void Awake()
    {
        if(spawnCollider == null)
        {
            

                spawnCollider = GetComponent<Collider>();
                
            
        }

        bounds = spawnCollider.bounds;

    }

    private void OnEnable()
    {
        if(spawnCoroutine == null)
        {
            spawnCoroutine = StartCoroutine(SpawnEnemies());
        }
    }
    private Vector3 GetRandomPositionInBounds()
    {
        return new Vector3(Random.Range(bounds.min.x, bounds.max.x), bounds.min.y, Random.Range(bounds.min.z, bounds.max.z));
    }
    private IEnumerator SpawnEnemies()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnDelay);
       
            for(int i = 0; i < spawnCount; i++)
            {
                if (spawnMethod == EnemySpawner.SpawnMethod.RoundRobin)
                {
                     spawner.DoSpawnEnemy(spawner.enemyPrefabs.FindIndex((enemy) => enemy.Equals(enemies[i % enemies.Count])), GetRandomPositionInBounds());
            }
                else if (spawnMethod == EnemySpawner.SpawnMethod.Random)
                {
                    int index = Random.Range(0, enemies.Count);
                    spawner.DoSpawnEnemy(spawner.enemyPrefabs.FindIndex((enemy) => enemy.Equals(enemies[index])), GetRandomPositionInBounds()); 
                }
               yield return wait;
            }
            
        
        Destroy(gameObject);
    }
}
