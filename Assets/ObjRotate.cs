using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjRotate : MonoBehaviour
{
    private Vector3 startRot;
    private Vector3 newRot;

    void Start()
    {
        startRot = transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (LerpScript.currentState == LerpScript.lerpState.Rotate)
        {
            newRot.z = startRot.z + (-LerpScript.lerpVal * 360);
            transform.localEulerAngles = newRot;
        }
    }
}
