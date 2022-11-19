using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float range = 100f;
    public float speed;
    
    Vector3 initialPosition = Input.mousePosition;
    public bool check = false;
    public float moveSpeed = 10f;
    public float rotateSpeed = 100f;

    void Look()
    { Vector3 mousePos = Input.mousePosition;
        void CheckMovement()
        {
            var xMove = transform.right * (Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime);
            var zMove = transform.forward * (Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime);
            var move = xMove + zMove;

            transform.position += move;
        
    
        
        


            /*mousePos.z = fpsCam.transform.position.z;
            Ray ray = fpsCam.ScreenPointToRay(mousePos);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100)) ;
            {
                Vector3 move = hit.point;
                move.y = transform.position.y;
                move.z = transform.position.z;
                transform.position = Vector3.MoveTowards(transform.position, move, speed);
                Debug.DrawRay(mousePos, move);
            }*/
        }
    }
// Start is called before the first frame update
void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Look();
    }
}
