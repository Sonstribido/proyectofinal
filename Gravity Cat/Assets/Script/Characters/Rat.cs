using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : MonoBehaviour
{

    private Transform posJugador;
    public float speed = 4f;
    public float maxDistancia = 20f;
    public Animator anim;
    public float sightDist = 30f;
    protected Ray sight;
    public GameObject prefab;
    public new string name;
    public float eatingTime = 4;
    public Transform posQuesito;
    public bool distracted = false;

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
        transform.position = Vector3.MoveTowards(transform.position, posQuesito.transform.position, speed * Time.deltaTime);
        anim.SetBool("walk", true);
    }

    protected void BuscarComida()
    {
      
        if (distracted == false)
        {
            LookAtPlayer();
            SeguirAlJugador();
        }
    }

    public void Info()
    {
        Debug.Log(name + " is a rat that can smell you from " + maxDistancia + " meters at " + speed + " units of ratspeed");
    }
    
    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.CompareTag("CheeseTrap"))
        {
            distracted = true;
            transform.LookAt(col.transform.position);
            transform.position = Vector3.MoveTowards(transform.position, col.transform.position, speed * Time.deltaTime);
            anim.SetBool("walk", true);
            

        }
         else if (col.gameObject.CompareTag("Player"))
        {           
            transform.LookAt(col.transform.position);
            transform.position = Vector3.MoveTowards(transform.position, col.transform.position, speed * Time.deltaTime);
            anim.SetBool("walk", true);


        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("CheeseTrap"))
        {
            if (other.gameObject.CompareTag("Player"))
            {
                posJugador = other.transform;
            };
            if (other.transform.position == transform.position)
            {
                eatingTime -= Time.deltaTime;
            };
            transform.LookAt(other.transform.position);
            transform.position = Vector3.MoveTowards(transform.position, other.transform.position, speed * Time.deltaTime);
        };
        if (other.gameObject.CompareTag("Player"))
        {
            posJugador = other.transform;
        };
       
        if (eatingTime <= 0)
            {

                Destroy(other.transform.gameObject);
                distracted = false;
                eatingTime = 3;

            

        };
            
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("CheeseTrap"))
        {


        }
    }
    void Update()
        {
            BuscarComida();

        }


    }



