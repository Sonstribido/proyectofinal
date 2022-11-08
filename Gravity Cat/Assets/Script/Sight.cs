using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sight : MonoBehaviour
{
    /* [SerializeField] private float maxDistance;
     [SerializeField] private LayerMask layerToCollide;*/
    public float range = 100f;
    public float speed;
    public Camera fpsCam;
    public float puertaAbiertaAngulo;
    public float puertaCerradaAngulo = 0.0f;
    public bool activar;
    public float relentizacion;





    void Start()
    {
        fpsCam = Camera.main;
    }

    void Update()
    {

        
            Look();

        
    }

    void Look()
    {  
        Vector3 mousePos = Input.mousePosition;

        mousePos.z = fpsCam.transform.position.z;
        Ray ray = fpsCam.ScreenPointToRay(mousePos);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100)) ;
        {
            Vector3 move = hit.point;
            move.y = transform.position.y;
            move.z = transform.position.z;
            transform.position = Vector3.MoveTowards(transform.position, move, speed);
            Debug.DrawRay(mousePos, move);
        }
    }
}
        /*RaycastHit hit;
        Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range);
        Debug.Log(hit.transform.name);

        if (hit.transform.CompareTag("Puertas"))
        {
            Quaternion targetRotation = Quaternion.Euler(0, puertaAbiertaAngulo, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, relentizacion * Time.deltaTime);
        }else {
            Quaternion targetRotation2 = Quaternion.Euler(0, puertaCerradaAngulo, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation2, relentizacion * Time.deltaTime);
        }
            Debug.Log ("Abres La Puerta");
        }*/

    
    /*private void Raycast()
    {
        RaycastHit hit;
        Ray ray;
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance, layerToCollide))
        {
            Debug.Log("vi algo a los " + hit.distance);
        }
    }*/

    