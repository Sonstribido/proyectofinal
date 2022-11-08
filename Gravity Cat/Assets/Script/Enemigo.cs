
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public Transform posJugador;
    public float speed = 2f;
    public float maxDistancia = 20f;
    public Animator anim;

    void Start()
    {
        
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
            speed = 0;
            anim.SetBool("walk",false);
        } else {
            speed = 2;
            
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
}

