using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kinecton : MonoBehaviour
{
    Rigidbody rb;
    public float fadeTimer = 5f;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

   void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.isKinematic = false;
        }
    }


    void Update()
    {
        if (rb.isKinematic == false)
        {
            fadeTimer -= Time.deltaTime;
        }
        if (fadeTimer <= 0)
        {
            Destroy(this.gameObject);
            fadeTimer = 5f;
        }
    }
}
