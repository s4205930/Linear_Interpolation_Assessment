using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private float speed = 10f;
    private float mouseSens = 1000f;
    void Update()
    {

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
        transform.position += move * speed * Time.deltaTime;

        Vector3 rotate = new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0f) * mouseSens * Time.deltaTime;
        //transform.Rotate(rotate);
        
    }

    public static void shake()
    {

        transform.localPosition += new Vector3(Mathf.PerlinNoise(0, Time.time) * 2 - 1,
            Mathf.PerlinNoise(0, Time.time) * 2 - 1,
            Mathf.PerlinNoise(0, Time.time) * 2 - 1) * 0.5f;

    }
}
