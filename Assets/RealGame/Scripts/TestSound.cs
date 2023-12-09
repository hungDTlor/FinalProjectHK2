using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSound : MonoBehaviour
{
    public float soundRange = 20f;
    float timer = 0.5f;
    
    public void Update()
    {
        Breathing();
    }
    private void Start()
    {
         
    }
    public void Breathing()
    {
        
        timer -= Time.deltaTime;
        if(timer <=0)
        {
            timer = 0.5f;
            var sound = new Sound(this.transform.position, soundRange);
            Sounds.MakeSound(sound);
        }
            
        
    }
}
