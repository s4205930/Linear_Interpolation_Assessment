using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjTranslate : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 newPos;
    private float xPos = 0f;
    private float xPosNew = 0f;

    void Update()
    {
        if (LerpScript.currentState == LerpScript.lerpState.Translate)
        {
            newPos.x = startPos.x + xPosNew;
            newPos.y = startPos.y + LerpScript.t * 10;
            newPos.z = startPos.z;
            transform.position = newPos;
        }
    }
}
