using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torque : MonoBehaviour
{
   
    public float forceAmount;
    public Rigidbody rb;

   
    void Torquen()
    {
        rb.AddTorque(Vector3.back * forceAmount);
    }
    
    void FixedUpdate()
    {

        Torquen();


        /*
         Torquen();
        float movX = 5f;
         float movY = 5f;
         float h = movX  * forceAmount * Time.deltaTime; 
         float v = movY * forceAmount * Time.deltaTime; 

         rb.AddTorque(transform.up * v);
         rb.AddTorque(transform.right * h);*/
    }
    void Start()
    {
        


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
