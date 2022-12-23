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
    public float eatingTime = 4;
    public GameObject Quesito;

    protected void LookAtPlayer()
    {
        transform.LookAt(posJugador);
    }
    protected void SeguirAlJugador()
    {
        transform.position = Vector3.MoveTowards(transform.position, posJugador.position, speed * Time.deltaTime);
        anim.SetBool("walk", true);
    }
    protected void SeguirAlQuesito()
    {
        transform.position = Vector3.MoveTowards(transform.position, Quesito.transform.position, speed * Time.deltaTime);
        anim.SetBool("walk", true);
    }

    protected void BuscarComida()
    {
        float dist = Vector3.Distance(posJugador.position, transform.position);
        float distQueso = Vector3.Distance(Quesito.transform.position, transform.position);
        speed = 5;
       if (dist < maxDistancia && dist < distQueso)
        {
            LookAtPlayer();
            SeguirAlJugador();
        } else if (dist > distQueso)
        {
            SeguirAlQuesito();
        }
    }

    public void Info()
    {
        Debug.Log(name + " is a rat that can smell you from " + maxDistancia + " meters at " + speed + " units of ratspeed");
    }

    void OnTriggerStay(Collider col)
    {
       
        if (col.gameObject.CompareTag("Cheese"))
        { 

            speed = 0;
            eatingTime -= Time.deltaTime;
            if (eatingTime <= 0)
            {
                Destroy(col.transform.gameObject);
                speed = 4;
                eatingTime = 3;
            }

        };
    }
        void Update()
        {
            BuscarComida();

        }

    
}


