using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : MonoBehaviour
{

    public Transform posJugador;
    public float speed = 4f;
    public float maxDistancia = 20f;
    public Animator anim;
    public float sightDist = 30f; 
    protected Ray sight;
    public GameObject prefab;
    public new string name;

    
    protected void LookAtPlayer()
    {
        transform.LookAt(posJugador);
    }
    protected void SeguirAlJugador()
    {
        transform.position = Vector3.MoveTowards(transform.position, posJugador.position, speed * Time.deltaTime);
        anim.SetBool("walk", true);
    }
    

    protected void BuscarComida() {
        float dist = Vector3.Distance(posJugador.position, transform.position);
        

        if (dist < maxDistancia) {
            LookAtPlayer();
            SeguirAlJugador(); 
        } 
    }

    public void Info()
    {
        Debug.Log(name + " is a rat that can smell you from " + maxDistancia + " meters at " + speed + " units of ratspeed");
    }

    /*void OnTriggerEnter(Collider col) {
        if (col.gameObject.CompareTag("Player")) {
        };*/

    void Update()
    {
        BuscarComida();

    }

}


