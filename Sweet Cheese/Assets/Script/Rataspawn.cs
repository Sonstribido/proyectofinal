using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rataspawn : MonoBehaviour

{
    public GameObject prefab;
    public List<Transform> spawnEnemigo = new List<Transform> ();
    void Start()
    {

    }
    void Update()
    {
        
    }
        
    void OnTriggerEnter(Collider col) {
        if (col.gameObject.CompareTag("Player")) {
            Instantiate(prefab,spawnEnemigo[Random.Range(0,spawnEnemigo.Count)].position, transform.rotation);    
        }
    

    // Update is called once per frame
    
}}
