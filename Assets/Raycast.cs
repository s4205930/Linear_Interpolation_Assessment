using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Raycast : MonoBehaviour
{

    
    void Start()
    {        
    }

    // Update is called once per frame
    void Update()
    { 

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.DrawLine(ray.origin, hit.point, Color.red, 5f);
                if (hit.transform.TryGetComponent(out MoveObject mo)) { 
                    mo.startLerp();
                }
            }
        }else if (Input.GetMouseButtonDown(1))
        {
            //CameraMovement.shake();
        }

    }
}
