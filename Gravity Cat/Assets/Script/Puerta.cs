using UnityEngine;

public class Puerta : MonoBehaviour
{
    public Transform tpPoint;
    public GameObject Personaje2_prefab;
    private bool tpd;

    

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player") && tpd == false)
        {
            Instantiate(Personaje2_prefab, tpPoint.position, tpPoint.rotation);
            tpd = true;
            Debug.Log("Tepeado");
        } 
    
}
}
