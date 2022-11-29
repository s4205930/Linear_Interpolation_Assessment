using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static LerpScript;

public class ObjCombo : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 newPos;
    private Vector3 startRot;
    private Vector3 newRot;
    void Start()
    {
        //Initialise the start position and roation of the object
        startPos = transform.position;
        startRot = transform.eulerAngles;
    }

    void Update()
    {
        // if the current state is combination a series of if statements apply the lerp if the toggle is true
        if (currentState == lerpState.Combination)
        {
            if (UI_Controller.tranBool)
            {
                newPos.x = startPos.x + xPosNew;
                newPos.y = startPos.y + lerpVal * 10;
                newPos.z = startPos.z;
                transform.position = newPos;
            }
            else
            {
                transform.position = new Vector3(startPos.x + 5, startPos.y + 5, startPos.z);
            }
            if (UI_Controller.rotBool)
            {
                newRot.z = startRot.z + (-lerpVal * 360);
                transform.localEulerAngles = newRot;
            }
            if (UI_Controller.scaBool)
            {
                transform.localScale = Vector3.one * (lerpVal + 1) * 1.5f;
            }
        }
    }
}
