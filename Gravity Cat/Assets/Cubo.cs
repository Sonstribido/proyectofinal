using UnityEngine;

public class Cubo : MonoBehaviour
{
    public Vector3 escala;
    public Vector3 posicion;
    public float cubeSpeed = 20f;
    void Start()
    {   
        transform.localScale = escala;
    }

   
    void Update()
    {
        transform.position += posicion * cubeSpeed;
    }
}
