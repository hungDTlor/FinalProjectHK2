using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    public Transform player;
    public int enemyNumbers = 2;
    public float spawnDelay = 2f;
    public List<EnemyScriptableObject> enemyPrefabs = new List<EnemyScriptableObject>();

    private Dictionary<int,ObjectPool> enemyObjectPools = new Dictionary<int,ObjectPool>();
    public SpawnMethod enemySpawnMethod = SpawnMethod.RoundRobin;
    private NavMeshTriangulation triangulation;    
    [SerializeField] Collider collider;    
    private Bounds bound;
    

    private void Awake()
    {
     
        collider = GetComponent<Collider>();
        bound = collider.bounds;    
        //dayColliders = GetComponentsInChildren<Collider>();
        //for(int i = 0; i < dayColliders.Length; i ++)
        //{
        //    bounds[i] = dayColliders[i].bounds;
            
        //}

        for (int i = 0; i < enemyPrefabs.Count; i++)
        {
            enemyObjectPools.Add(i, ObjectPool.CreateInstance(enemyPrefabs[i].prefab, enemyNumbers));
        }

        //if (spawnCollider == null)
        //{
        //    spawnCollider = GetComponent<Collider>();
        //}
        //bounds = spawnCollider.bounds;

    }

    private void Start()
    {
        triangulation = NavMesh.CalculateTriangulation();
       
    }

    
    public void SpawnEnemy()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {        
        yield return new WaitForSeconds(spawnDelay);

        int spawnedEnemies = 0;
        while (spawnedEnemies < enemyNumbers)
        {
            if (enemySpawnMethod == SpawnMethod.RoundRobin)
            {
                SpawnRoundRobinEnemy(spawnedEnemies, bound);
            }
            else if (enemySpawnMethod == SpawnMethod.Random)
            {
                SpawnRandomEnemy();
            }
            spawnedEnemies++;
        }


        //for (int i = 0; i < dayColliders.Length; i++)
        //{
        //    WaitForSeconds wait = new WaitForSeconds(spawnDelay);
        //    int spawnedEnemies = 0;
        //    while (spawnedEnemies < enemyNumbers)
        //    {
        //        if (enemySpawnMethod == SpawnMethod.RoundRobin)
        //        {
        //            SpawnRoundRobinEnemy(spawnedEnemies, bounds);
        //        }
        //        else if (enemySpawnMethod == SpawnMethod.Random)
        //        {
        //            SpawnRandomEnemy();
        //        }
        //        spawnedEnemies++;
        //        yield return wait;
        //    }
        //}

    }

    private void SpawnRoundRobinEnemy(int spawnedEnemies,Bounds bounds)
    {
        int spawnIndex = spawnedEnemies % enemyPrefabs.Count;
        DoSpawnEnemy(spawnIndex,GetRandomPositionInBounds(bounds));
    }

    private void SpawnRandomEnemy()
    {
        DoSpawnEnemy(Random.Range(0, enemyPrefabs.Count), ChooseRandomPositionOnNavMesh());
    }
    private Vector3 ChooseRandomPositionOnNavMesh()
    {
        int vertexIndex = Random.Range(0, triangulation.vertices.Length);
        return triangulation.vertices[vertexIndex];
    }

    private Vector3 GetRandomPositionInBounds(Bounds bounds)
    {
        return new Vector3(Random.Range(bounds.min.x, bounds.max.x), bounds.min.y, Random.Range(bounds.min.z, bounds.max.z));
    }
    public void DoSpawnEnemy(int spawnIndex,Vector3 spawnPosition)
    {
        PoolableObject poolableObject = enemyObjectPools[spawnIndex].GetObject();
        if(poolableObject != null)
        {
            Enemy1 enemy = poolableObject.GetComponent<Enemy1>();
            enemyPrefabs[spawnIndex].SetUpEnemy(enemy);
            NavMeshHit hit;
            if (NavMesh.SamplePosition(spawnPosition, out hit, 2f, -1))
            {
                enemy.navMeshAgent.Warp(hit.position);
                enemy.navMeshAgent.enabled = true;
            }
        }
        else
        {

        }
    }
    public enum SpawnMethod
    {
        RoundRobin,Random
    }

}
