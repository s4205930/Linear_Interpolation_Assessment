using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static LerpScript;

public class ObjScale : MonoBehaviour
{
    void Update()
    {
        if (currentState == lerpState.Scale)
        {
            transform.localScale = Vector3.one * (lerpVal + 1) * 3;
        }
    }
}
