using UnityEngine;

public class RollingTube : Obstacle
{
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    protected override void TorquenAlt()
    {
        float movX = -2f;
        float movY = 0f;
        float movZ = 0f;
        float forback = movX * forceAmount * Time.deltaTime;
        float gravity = movY * forceAmount * Time.deltaTime;
        float rightleft = movZ * forceAmount * Time.deltaTime;
        rb.AddTorque(new Vector3(forback, gravity, rightleft) * forceAmount);
    }
    // Update is called once per frame
    void Update()
    {
        TorquenAlt();
    }
}
