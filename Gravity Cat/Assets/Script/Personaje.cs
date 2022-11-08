using UnityEngine;

public class Personaje : MonoBehaviour
{
    Vector3 posInicial;
    public Transform tp1;
    public Transform tp2;
    public Transform inicio;
    public float speed = 2f;
    public Animator anim;
    public float forceAmount;
    public Rigidbody rb;
    private bool lvl1 = true;
    private bool lvl2 = false;
    private bool lvl3 = false;
    public float rotateSpeed = 0.5f;
    float vel = 0.0f;
    public float acel = 3f;
    public float desacel = 1f;
    public bool jumping = false;
    public float jumpCd = 3;

    void Respawn()
    {
        if (lvl1 == true)
        {
            transform.position = posInicial;
        }
        else if (lvl2 == true) { transform.position = tp1.position; }
        else if (lvl3 == true)
        {
            transform.position = tp2.position;

        }
    }
    void RespawnFinal()
    {
        transform.position = posInicial;
    }

    void CheckRotation()
    {
        var rotation = Input.GetAxisRaw("Mouse X") * rotateSpeed * Time.deltaTime * 500;

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
        }
        else if ((col.gameObject.CompareTag("Puertas") && lvl2 == true))
        {
            transform.position = tp2.position;
            lvl3 = true;
            lvl2 = false;
        }


        if (col.gameObject.CompareTag("rata"))
        {
            RespawnFinal();


        }
    }


    void Start()
    {


    }

    void FixedUpdate()
    {


    }
    void Update()
    {
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