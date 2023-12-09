using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool 
{
    private GameObject parent;
    private PoolableObject prefab;
    private List<PoolableObject> availableObjects;
    private EnemySpawner spawner;
    private int size;
    
    private ObjectPool(PoolableObject prefab, int size)
    {
        this.prefab = prefab;
        availableObjects = new List<PoolableObject>(size);
    }
    
    public static ObjectPool CreateInstance(PoolableObject prefab , int size)
    {
        ObjectPool pool = new ObjectPool(prefab, size);
        pool.parent = new GameObject(prefab.name + " pool");
        pool.CreateObjects();
        return pool;
    }

    public void CreateObjects()
    {
        for( int i = 0; i < size; i++ )
        {
            CreateObject();
        }
    }
    private void CreateObject()
    {
        PoolableObject poolableObject = GameObject.Instantiate(prefab, Vector3.zero, Quaternion.identity, parent.transform);
        poolableObject.Parent = this;
        poolableObject.gameObject.SetActive(false);
    }
    public void ReturnObjectToPool(PoolableObject poolableObject)
    {
        availableObjects.Add(poolableObject);
    }
   
    public PoolableObject GetObject()
    {
        if( availableObjects.Count == 0 )
        {
            CreateObject();
        }
        if(availableObjects.Count > 0)
        {
            PoolableObject instance = availableObjects[0];
            availableObjects.RemoveAt(0);
            instance.gameObject.SetActive(true);
             return instance;

        }
        else
        {
            Debug.LogError($"Could not get an object from pool \"{prefab.name}\" Pool.Probably a configuration issue ");
            return null;
        }
                
    }
}
