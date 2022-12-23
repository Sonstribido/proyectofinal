using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigger : Obstacle
{
    public GameObject obstacleToSpawn;
    
    void Start()
    {

    }

 // Update is called once per frame
    void FixedUpdate()
    {

        timedSpawn();



    }
    public void OnTriggerEnter(Collider other)
    { if (other.gameObject.CompareTag("Player") && spawning == false)
        {
            
            spawning = true;
            
        }
    }
   
}

    
