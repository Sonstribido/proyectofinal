using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector3 initialPosition;
    public bool check = false;
    public float moveSpeed = 10f;
    public float rotateSpeed = 100f;
    public float timeGoldenWall = 0;
    int rndX;
    int rndZ;
    float qtrX;
    float qtrY;
    float qtrZ;
    float qtrW;

    void Start()
    {
        
    }
    void Update()
    {
       
        CheckMovement();
        CheckRotation();
        if (transform.position.y < -20)
        {
            Respawn();
        }
    }

    void OnTriggerEnter(Collider col)
    {

        Debug.Log(col.transform.gameObject.name);
    }

    void OnTriggerStay(Collider col)
    {
       if (col.transform.gameObject.name == "GoldenWall")
        {
            timeGoldenWall += Time.deltaTime;
            if (timeGoldenWall > 2)
            {
                rndX = Random.Range(-20, 20);               
                rndZ = Random.Range(-20, 20);
                col.transform.position = new Vector3(rndX, 1, rndZ);
                qtrX = Random.Range(0, 180);
                qtrY = Random.Range(0, 180);
                qtrZ = Random.Range(0, 180);
                qtrW = Random.Range(0, 180);
                col.transform.rotation = new Quaternion(qtrX, qtrY, qtrZ, qtrW);
                 /* (este lo encontré en internet pero no se si está bien) col.transform.rotation = Random.rotation; */
                timeGoldenWall = 0;
            }
        } 
    }


    void OnTriggerExit(Collider portal)
    {
        if (portal.transform.gameObject.name == "Portal" && check == false)
        {
            transform.localScale /= 1.3f;
            check = true;
            Debug.Log("Jugador se achica");

             
        } else if (portal.transform.gameObject.name == "Portal" && check == true)
        {
            transform.localScale *= 1.3f;
            check = false;
            Debug.Log("Jugador vuelve a su tamaño");
        }
    }

    void CheckMovement()
    {
        var xMove = transform.right * (Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime);
        var zMove = transform.forward * (Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime);
        var move = xMove + zMove;

        transform.position += move;
    }
    void Respawn()
    {
        transform.position = initialPosition;
    }
        void CheckRotation()
    {
        var rotation = Input.GetAxisRaw("Mouse X") * rotateSpeed * Time.deltaTime * 500;

        transform.Rotate(0f, rotation, 0f);
    }
    
    
}
