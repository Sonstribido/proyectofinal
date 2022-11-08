using UnityEngine;

public class Personaje : MonoBehaviour
{
  Vector3 posInicial;
  public float speed = 2f;
  public Animator anim;
  public float forceAmount;
    public Rigidbody rb;
    public int vidas;
    private int vidasRestantes;
   public Transform principioNivel;
   public float rotateSpeed = 0.5f;
   float vel = 0.0f;
   public float acel = 3f;
   public float desacel = 1f;
  private bool jumping = false;
  private float jumpCd = 1f;
  
    void Start()
  {
    posInicial = transform.position;
        vidasRestantes = vidas;
    }

  void FixedUpdate()
    { 
      

    }
    void Update()
  {     
        if (Input.GetKeyDown(KeyCode.Space) && jumping == false) {
          anim.SetBool( "jump", true);
          rb.AddForce(new Vector3(0, forceAmount * 5, 0), ForceMode.Impulse);
          jumping = true;
          jumpCd = 1f; 
          anim.SetBool( "jump", true);
          
        } 
        else 
        { 
          anim.SetBool( "jump", false);
        } ;
        if (jumping == true){
          jumpCd -= Time.deltaTime;
        } 
        if (jumpCd <= 0){
          jumping = false;
        }; 
        MovimientoJugador();
        CheckRotation();

        if (transform.position.y < -20){
      Respawn();
        }
        if (vidasRestantes <= 0)
        {
            RespawnFinal();
            Revive();
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Danador"))
        {
            vidasRestantes -= 1;
            Respawn();
            Debug.Log(" Te quedan " + vidasRestantes + " vidas");
        }
        if (col.gameObject.CompareTag("rata"))
        {
            Respawn();
        }

        
    }
    void Revive()
    {
        vidasRestantes = vidas;
    }
    void Respawn(){
      transform.position = posInicial;
  }
    void RespawnFinal()
    {
        transform.position = principioNivel.position;
    }
    void MovimientoJugador(){
        float movX = Input.GetAxis("Horizontal");
        float movY = Input.GetAxis("Vertical");
        Vector3 inputJugador = new Vector3(movX,0, movY);
        transform.Translate(inputJugador * speed * Time.deltaTime) ;
        
        //animaciones con velocidad

        bool adelante = Input.GetKey("w");
        
        if (adelante && vel < 0.5f){
          vel += Time.deltaTime * acel;
        };
        if (!adelante && vel > 0.0f){
          vel -= Time.deltaTime * desacel;
        }
        anim.SetFloat("velocidad",vel);

      bool correr = Input.GetKey("e");
        
        if (correr && vel < 1f){
          vel += Time.deltaTime * acel;
        }
        if (!correr && vel > 0.5f){
          vel -= Time.deltaTime * desacel;
        }
        anim.SetFloat("velocidad",vel);
}
void CheckRotation()
    {
        var rotation = Input.GetAxisRaw("Mouse X") * rotateSpeed * Time.deltaTime * 500;

        transform.Rotate(0f, rotation, 0f);
    }
}
