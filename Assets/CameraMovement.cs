using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private float speed = 10f;
    void Update()
    {

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        //transform.position += move * speed * Time.deltaTime;


        
        
    }

    public void shake()
    {

        transform.localPosition += new Vector3(Mathf.PerlinNoise(0, Time.time) * 2 - 1,
            Mathf.PerlinNoise(0, Time.time) * 2 - 1,
            Mathf.PerlinNoise(0, Time.time) * 2 - 1) * 0.5f;

    }
}
