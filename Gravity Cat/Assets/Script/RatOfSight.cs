using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatOfSight : Rat
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    protected void VerComida()
    {

        

        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        sight.origin = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);

        sight.direction = transform.forward;

        LookAtPlayer();

        if (Physics.Raycast(sight, out RaycastHit rayHit, sightDist))
        {


            Debug.DrawLine(sight.origin, rayHit.point, Color.red);

            if (rayHit.collider.CompareTag("Player"))
            {

                SeguirAlJugador();
                Debug.Log("Te estan viendo");

            }



            /*f (!rayHit.collider.CompareTag("Player") && !rayHit.collider.CompareTag("Enemy"))
            {

                

            }*/

        }
    }

    // Update is called once per frame
    void Update()
    {

    VerComida();


    }
}
