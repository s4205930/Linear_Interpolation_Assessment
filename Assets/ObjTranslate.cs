using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjTranslate : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 newPos;

    private void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        if (LerpScript.currentState == LerpScript.lerpState.Translate)
        {
            newPos.x = startPos.x + LerpScript.xPosNew;
            newPos.y = startPos.y + LerpScript.lerpVal * 10;
            newPos.z = startPos.z;
            transform.position = newPos;
        }
    }
}
