
using UnityEngine;

public class RaycastShoot : MonoBehaviour
{
    [SerializeField] private float maxDistance;
    [SerializeField] private LayerMask layerToCollide;
    private void Raycast()
    {
        RaycastHit hit;
        Ray ray;
        if(Physics.Raycast(transform.position,transform.forward, out hit, maxDistance, layerToCollide))
        {
            Debug.Log("vi algo a los " + hit.distance);
        }
    }
    // Start is called before the first f
    // rame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Raycast();
    }
}
