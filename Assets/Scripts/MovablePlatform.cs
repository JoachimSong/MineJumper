using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovablePlatform : MonoBehaviour
{
    private float g = 9.79f;
    private float y;
    private float x;
    private float z;
    private float v;
    private float startZ;

    public float minZ;
    private int step = 1; // You can change this!
    private int count; // used to control the frequency of updates

    // TODO: complete the function with Explicit Euler method
    void UpdateHeight()
    {
        // 1. update height, move at speed of v for one time step
        z = z + v * Time.deltaTime * step;
        // 2. calculate v in the next time step
        v = v - g * Time.deltaTime * step;
        // 3. change direction if needed, reset initial values
        if (z <= minZ) 
        {
            v = -v;
        }
        if (z > startZ)
        {
            z = startZ;
            v = 0;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // set initial values
        y = transform.position.y;
        x = transform.position.x;
        z = transform.position.z;
        startZ = z;
        v = 0;
        count = 0;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        count++;
        if (count >= step)
        {
            // calculate new position
            UpdateHeight();
            // set new position
            transform.position = new Vector3(x, y, z);
            count = 0;
        }
    }
}
