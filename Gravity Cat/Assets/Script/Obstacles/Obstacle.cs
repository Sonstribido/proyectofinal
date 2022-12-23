using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject obstaclePrefab;
    public float timeSpawn;
    public float timeNextSpawn;
    public bool spawning;
    public float forceAmount;
    public Rigidbody rb;
    

    public void Torquen()
    {   
        rb.AddTorque(new Vector3(-1, 0, 0) * forceAmount);
    }

   protected virtual void TorquenAlt()
    {
        float movX = 0f;
        float movY = 0f;
        float movZ = 0f;
        float forback = movX  * forceAmount * Time.deltaTime; 
        float gravity = movY * forceAmount * Time.deltaTime;
        float rightleft = movZ * forceAmount * Time.deltaTime;
        rb.AddTorque(new Vector3(forback, gravity, rightleft) * forceAmount);
        
    }
    public void ResetTimer()
    {
        timeNextSpawn = timeSpawn;
    }
    public void timedSpawn()
    {

        if (spawning == true && timeNextSpawn <= 0)
        {
            
            Instantiate(obstaclePrefab, spawnPoint.position, spawnPoint.rotation);

            ResetTimer();

        }
        else if (spawning == true)
        {
            timeNextSpawn -= Time.deltaTime;
        }

       
    }
    public void spawnActivate() {

        if (spawning == false)
        {
            spawning = true;
        } else if(spawning == true ) 
        {
            spawning = false;
        }

        }

    }





