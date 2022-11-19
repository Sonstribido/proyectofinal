using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public Transform posJugador;
    public float speed = 2f;
    public float maxDistancia = 20f;
    public Animator anim;
    public List<Transform> spawnEnemigo = new List<Transform> ();
    void Start()
    {
        transform.position = spawnEnemigo[Random.Range(0,spawnEnemigo.Count)].position;
    }
    void Update()
    {
        ChequearDistancia();
        LookAtPlayer();
        SeguirAlJugador();
    }
    void ChequearDistancia(){
        float dist = Vector3.Distance(posJugador.position , transform.position);
        Debug.Log(dist);
        if (dist > maxDistancia){
            speed = 2;
            anim.SetBool("walk",false);
        } else {
            speed = 4;
            
        };  
    }
    void LookAtPlayer(){
        transform.LookAt(posJugador);
    }
    void SeguirAlJugador()
    {
        transform.position = Vector3.MoveTowards(transform.position, posJugador.position, speed * Time.deltaTime);
        anim.SetBool("walk",true);
    }
    void OnTriggerEnter(Collider col) {
        if (col.gameObject.CompareTag("Player")) {
        };

    }
}

