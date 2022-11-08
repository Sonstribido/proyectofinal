using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torqueactivate : MonoBehaviour
{
    public Rigidbody rb;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Personaje"))
        {
            rb.isKinematic = false;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
