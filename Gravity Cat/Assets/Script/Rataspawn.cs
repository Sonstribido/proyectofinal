using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rataspawn : MonoBehaviour

{
    public List<Transform> spawnEnemigo = new List<Transform>();
    GameObject prefab;

    public void Spawn()
    {
        Instantiate(prefab, spawnEnemigo[Random.Range(0, spawnEnemigo.Count)].position, transform.rotation);
    }
    void Start()
    {
        Rat ratSmell = new Rat();
        ratSmell.speed = 4f;
        ratSmell.name = "Smell";
        ratSmell.maxDistancia = 20f;
        ratSmell.Info();

        Rat ratSmeller = new Rat();
        ratSmeller.speed = 5f;
        ratSmeller.name = "Smeller";
        ratSmeller.maxDistancia = 25f;
        ratSmeller.Info();

        Rat ratSmellest = new Rat();
        ratSmellest.speed = 6f;
        ratSmellest.name = "Smellest";
        ratSmellest.maxDistancia = 30f;
        ratSmellest.Info();


        RatOfSight seerRat = new RatOfSight();
        seerRat.speed = 7f;
        seerRat.name = "Seer";


        Debug.Log("The " + seerRat.name + " will use its sight to follow the player if it gets closer than " + seerRat.sightDist + " meters at " + seerRat.speed + " units of ratspeed");



    }
    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Spawn();
        }


        // Update is called once per frame

    }
}
