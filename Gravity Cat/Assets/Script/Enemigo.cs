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
    private Ray sight;
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
        sight.origin = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);

        sight.direction = transform.forward;


        Vector3 fwd = transform.TransformDirection(Vector3.forward);



        if (Physics.Raycast(sight, out RaycastHit rayHit, dist))
        {

            Debug.DrawLine(sight.origin, rayHit.point, Color.red);

            if (rayHit.collider.CompareTag("Player"))
            {

                Debug.Log("Te estan viendo");

            }



            if (!rayHit.collider.CompareTag("Player") && !rayHit.collider.CompareTag("Enemy"))
            {

                

            }

        }
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

