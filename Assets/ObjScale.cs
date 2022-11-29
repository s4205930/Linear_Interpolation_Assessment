using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static LerpScript;

public class ObjScale : MonoBehaviour
{
    void Update()
    {
        //update the scale of the object using the lerp val if the lerpstate is scale
        if (currentState == lerpState.Scale)
        {
            transform.localScale = Vector3.one * (lerpVal + 1) * 2;
        }
    }
}
