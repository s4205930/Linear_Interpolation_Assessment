using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    void Update()
    {       
        
    }

    public static void camMove(bool direction)
    {

    }

    public void shake()
    {

        transform.localPosition += new Vector3(Mathf.PerlinNoise(0, Time.time) * 2 - 1,
            Mathf.PerlinNoise(0, Time.time) * 2 - 1,
            Mathf.PerlinNoise(0, Time.time) * 2 - 1) * 0.5f;

    }
}
