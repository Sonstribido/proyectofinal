using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public Transform spawnPoint;
    public Transform spawnPoint2;
    public Transform spawnPoint3;
    public Transform spawnPoint4;
    public GameObject obstaclePrefab;
    
    public float timeNextSpawn = 1f;
    public bool spawning;
    public float forceAmount;
    public Rigidbody rb;
    

    public void Torquen()
    {   
        rb.AddTorque(new Vector3(-1, 0, 0) * forceAmount);
    }

   protected virtual void TorquenAlt()
    {
        float movX = 2f;
        float movY = 0f;
        float movZ = 0f;
        float forback = movX  * forceAmount * Time.deltaTime; 
        float gravity = movY * forceAmount * Time.deltaTime;
        float rightleft = movZ * forceAmount * Time.deltaTime;
        rb.AddTorque(new Vector3(forback, gravity, rightleft) * forceAmount);
        
    }
    public void ResetTimer()
    {
        timeNextSpawn = 2f;
    }
    public void TimedSpawn()
    {

        if (spawning == true && timeNextSpawn <= 0)
        {
            
            Instantiate(obstaclePrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
            Instantiate(obstaclePrefab, spawnPoint2.transform.position, spawnPoint2.transform.rotation);
            Instantiate(obstaclePrefab, spawnPoint3.transform.position, spawnPoint3.transform.rotation);
            Instantiate(obstaclePrefab, spawnPoint4.transform.position, spawnPoint4.transform.rotation);
            ResetTimer();

        }
        else if (spawning == true)
        {
            timeNextSpawn -= Time.deltaTime;
        }

       
    }
    public void SpawnActivate() {

        if (spawning == false)
        {
            spawning = true;
        } else if(spawning == true ) 
        {
            spawning = false;
        }

        }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && spawning == false)
        {

            spawning = true;

        }
        
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") == true)
        {
            spawning = true;
            TimedSpawn();
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Danador"))
        {
            Destroy(other.transform.gameObject);
        };

        if (other.gameObject.CompareTag("Player"))
        {
            spawning = false;
        }
        
    }

}





