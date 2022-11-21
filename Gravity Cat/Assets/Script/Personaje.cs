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
    public float forceAmount;
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

    private void ShootRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))

        {

            Debug.Log(hit.transform.name);

            Debug.Log("hit");

        };
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

        if (col.gameObject.CompareTag("Puertas") && lvl1 == true)
        {
            transform.position = tp1.position;
            lvl2 = true;
            lvl1 = false;
            HUDGame.spawnInfo += 1;
        }
        else if ((col.gameObject.CompareTag("Puertas") && lvl2 == true))
        {
            transform.position = tp2.position;
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

        }

    }


    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined; // keep confined in the game window

        Cursor.lockState = CursorLockMode.Locked; // keep confined to center of screen

    }

    
    void Update()
    {
        ShootRay();
        if (Input.GetMouseButtonDown(1) && HUDGame.cantQuesito > 0)
        {
            quesos.Pop();
        };
            if (Input.GetKeyDown(KeyCode.Space) && jumping == false)
        {
            anim.SetBool("jump", true);
            rb.AddForce(new Vector3(0, forceAmount * 5, 0), ForceMode.Impulse);
            jumping = true;
            jumpCd = 2;


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
        };
        MovimientoJugador();
        CheckRotation();

        if (transform.position.y < -20)
        {
            Respawn();
        }




    }
}