using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quesito : MonoBehaviour
{
    public GameObject prefab;
    public Transform[] puntoQuesito;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0 ; i < puntoQuesito.Length; i++){
            Instantiate(prefab,puntoQuesito[i].position, transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
