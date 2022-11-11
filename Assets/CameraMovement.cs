using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private float speed = 10f;
    private float mouseSens = 1f;
    void Update()
    {

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
        transform.position += move * speed * Time.deltaTime;

        Vector2 rotate = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) * mouseSens * Time.deltaTime;
        transform.Rotate(rotate.x, rotate.y);
        
    }
}
