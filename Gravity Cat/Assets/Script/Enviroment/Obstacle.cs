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
    int rndZ;
    public float forceAmount;
    public Rigidbody rb;


    public void Torquen()
    {
        rb.AddTorque(new Vector3(-1, 0, 0) * forceAmount);
    }

   public void TorquenAlt()
    { float movX = 5f;
        float movY = 5f;
         float h = movX  * forceAmount * Time.deltaTime; 
         float v = movY * forceAmount * Time.deltaTime; 

         rb.AddTorque(transform.up * v);
         rb.AddTorque(transform.right * h);
    }
    public void ResetTimer()
    {
        timeNextSpawn = timeSpawn;
    }
    public void SpawnObstacle()
    {

        if (spawning == true && timeNextSpawn <= 0)
        {
            rndZ = Random.Range(1, 1);
            Instantiate(obstaclePrefab, spawnPoint.position += new Vector3(0, 0, rndZ), spawnPoint.rotation);

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





