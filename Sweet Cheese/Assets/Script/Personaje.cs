using UnityEngine;

public class Personaje : MonoBehaviour
{
  Vector3 posInicial;
  public float speed = 2f;
  public Animator anim;
  public float forceAmount;
  public Rigidbody rb;
    /* float vel = 0.0f;
    public float aceleracion = 0.3f;
    public float desaceleracion = 0.1f; */

    void Start()
  {
    posInicial = transform.position; 
  }

   void FixedUpdate()
    {

        
    }
    void Update()
  {
        if (Input.GetKeyDown("j")) rb.AddForce(new Vector3(0, forceAmount * 5, 0), ForceMode.Impulse)
         ;
        MovimientoJugador();

        if (transform.position.y < -20){
      Respawn();
    }
  }

    void OnCollisionEnter(Collision col)
    {
        if(col.transform.gameObject.name == "BolaMuerte")
        {
            Respawn();
        }
    }
    void Respawn(){
      transform.position = posInicial;
  }
  void MovimientoJugador(){
        float movX = Input.GetAxis("Horizontal");
        float movY = Input.GetAxis("Vertical");
        Vector3 inputJugador = new Vector3(movX,0, movY);
        transform.Translate(inputJugador * speed * Time.deltaTime) ;
        if(Input.GetKey(KeyCode.Q)){
            transform.Rotate(0,-1,0);
        };
        if(Input.GetKey(KeyCode.E)){
            transform.Rotate(0,1,0);
        };
        

            bool adelante = Input.GetKey("w");
        if (adelante ){
          anim.SetBool( "caminar", true);
        }else
        {
          anim.SetBool( "caminar", false);
        }
        if(Input.GetKeyDown(KeyCode.Space)){
          anim.SetBool( "correr",true);
          speed = 6f;
        };
        if(Input.GetKeyUp(KeyCode.Space)){
          anim.SetBool( "correr",false);
          speed = 2f;
        };
}
 
}