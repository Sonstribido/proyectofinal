using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
   
    public Transform tp1;
    public Transform tp2;
    public Transform inicio;
    public float speed = 2f;
    public Animator anim;
    public float forceAmount = 3f;
    public Rigidbody rb;
    public bool lvl1 = true;
    public bool lvl2 = false;
    public bool lvl3 = false;
    public float rotateSpeed = 0.5f;
    float vel = 0.0f;
    public float acel = 3f;
    public float desacel = 1f;
    public bool jumping = false;
    public float jumpCd = 3;
    Stack quesos = new Stack();
    public GameObject Quesito;
    public Transform poneQuesito;

    private void PonerQuesito()
    {
        if (Input.GetKeyDown(KeyCode.C) && HUDGame.cantQuesito >= 1){
            Instantiate(Quesito, poneQuesito.transform.position, transform.rotation);
            HUDGame.cantQuesito -= 1;
        }
        if (HUDGame.cantQuesito == 0)
        {

        }
    }    
   
    void Respawn()
    {
        if (lvl1 == true)
        {
            transform.position = inicio.position;
        }
        else if (lvl2 == true) { transform.position = tp1.position; }
        else if (lvl3 == true)
        {
            transform.position = tp2.position;

        }
    }


    void RespawnFinal()
    {
        transform.position = inicio.position;
        lvl1 = true;

    }

    void CheckRotation()
    {
        var rotation = Input.GetAxisRaw("Mouse X") * rotateSpeed * Time.deltaTime * 10000;

        transform.Rotate(0f, rotation, 0f);
    }

    void MovimientoJugador()
    {
        float movX = Input.GetAxis("Horizontal");
        float movY = Input.GetAxis("Vertical");
        Vector3 inputJugador = new Vector3(movX, 0, movY);
        transform.Translate(inputJugador * speed * Time.deltaTime);
        //animaciones con velocidad

        bool adelante = Input.GetKey("w");

        if (adelante && vel < 0.5f)
        {
            vel += Time.deltaTime * acel;
        };
        if (!adelante && vel > 0.0f)
        {
            vel -= Time.deltaTime * desacel;
        }
        anim.SetFloat("velocidad", vel);

        bool correr = Input.GetKey("e");

        if (correr && vel < 1f)
        {
            vel += Time.deltaTime * acel;
            speed =6;
        }
        if (!correr && vel > 0.5f)
        {
            vel -= Time.deltaTime * desacel;
        }
        anim.SetFloat("velocidad", vel);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Danador"))
        {
            Respawn();

        }

        

        if (col.gameObject.CompareTag("Puertas") && lvl1 == true && HUDGame.gotTutorialKey == true)
        {
            transform.position = tp1.position;
            lvl2 = true;
            lvl1 = false;
            HUDGame.spawnInfo += 1;
        }
        else if ((col.gameObject.CompareTag("Puertas") && lvl2 == true && HUDGame.gotRoomKey == true))
        {
            transform.position = tp2.transform.position;
            lvl3 = true;
            lvl2 = false;
            HUDGame.spawnInfo += 1;
        }


        if (col.gameObject.CompareTag("rata"))
        {
            RespawnFinal();
            HUDGame.spawnInfo = 1;

        }
    }

    void OnTriggerEnter(Collider col) {
        if (col.gameObject.CompareTag("Cheese")) {
            Destroy (col.transform.gameObject);
            quesos.Push("quesito");
            HUDGame.cantQuesito++;

        };
        if (col.gameObject.CompareTag("Key")) { 
        

            Destroy(col.transform.gameObject);
            HUDGame.gotTutorialKey = true;

        };
        if (col.gameObject.CompareTag("GreenKey"))
        {
            Destroy(col.transform.gameObject);
            HUDGame.gotGreenKey = true;
        };
        if (col.gameObject.CompareTag("RoomKey"))
        {
            Destroy(col.transform.gameObject);
            HUDGame.gotRoomKey = true;
        };
        if (col.gameObject.CompareTag("FirstKey"))
        {
            Destroy(col.transform.gameObject);
            HUDGame.gotFirstKey = true;
        };
        if (col.gameObject.CompareTag("SecondKey") && HUDGame.gotFirstKey == true)
        {
            Destroy(col.transform.gameObject);
            HUDGame.gotSecondKey = true;
        };
        if (col.gameObject.CompareTag("FinalKey") && HUDGame.gotSecondKey == true)
        {
            Destroy(col.transform.gameObject);
            HUDGame.gotFinalKey = true;
        };  
        if (HUDGame.gotFinalKey == true)
        {

        };

    }

    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined; // keep confined in the game window

        Cursor.lockState = CursorLockMode.Locked; // keep confined to center of screen

    }

    void Pause()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumping == false)
        {
            anim.SetBool("jump", true);
            rb.AddForce(new Vector3(0, forceAmount * 5, 0), ForceMode.Impulse);
            jumping = true;
            jumpCd = 1.5f;


        }
        else
        {
            anim.SetBool("jump", false);

        };
        if (jumping == true)
        {
            jumpCd -= Time.deltaTime;
        }
        if (jumpCd <= 0)
        {
            jumping = false;
        }
    }

    void FallRespawn ()
    {
        if (transform.position.y < -20)
        {
            Respawn();
        }

    }

    
    void Update()
    {
        PonerQuesito();
        Pause();
        Jump();
        MovimientoJugador();
        CheckRotation();
        FallRespawn();





    }
}