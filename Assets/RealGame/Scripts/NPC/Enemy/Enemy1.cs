
using UnityEngine;
using UnityEngine.AI;

public class Enemy1 : PoolableObject
{
    public AIAgent AIAgent;
    public NavMeshAgent navMeshAgent;   
    public int health;
    public float soundRange = 5f;

    public void Update()
    {
        
    }
    /*public void Breathing()
    {
        float timer = 0.2f;
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            var sound = new Sound(transform.position, soundRange);
            Sounds.MakeSound(sound);
        }

        
    }*/
}


    // Start is called before the first frame update
   

