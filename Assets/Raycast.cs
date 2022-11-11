using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    // Start is called before the first frame update
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
            if (Physics.Raycast(ray, out hit, 100f))
            {
                Debug.DrawLine(ray.origin, hit.point, Color.red, 5f);
                if (hit.transform.TryGetComponent(out CustomLerp mo)) { mo.StartLerp(); }
            }
        }

    }
}
