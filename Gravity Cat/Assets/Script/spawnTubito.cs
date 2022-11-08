using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnTubito : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject killerTube_prefab;
    public float timeSpawn;
    private float timeNextSpawn;
    public bool spawning;
    int rndZ;
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (spawning == true && timeNextSpawn <= 0)
        {
            rndZ = Random.Range(1, 1);
            Instantiate(killerTube_prefab, spawnPoint.position += new Vector3 (0,0,rndZ), spawnPoint.rotation);
            
            ResetTimer();
            
        }
        else if (spawning == true) {
            timeNextSpawn -= Time.deltaTime;
        }
        

    }
    public void OnTriggerEnter(Collider other)
    { if (other.gameObject.CompareTag("Player") && spawning == false)
        {
            
            spawning = true;
            
        }
    }
    private void ResetTimer()
    {
        timeNextSpawn = timeSpawn;
    }
}

    
