using UnityEngine;

public class ObjRotate : MonoBehaviour
{
    private Vector3 startRot;
    private Vector3 newRot;

    void Start()
    {
        //Initialise the start rotation of the object
        startRot = transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        //update the rotation of the object using the lerp val if the lerpstate is rotate
        if (LerpScript.currentState == LerpScript.lerpState.Rotate)
        {
            newRot.z = startRot.z + (-LerpScript.lerpVal * 360);
            transform.localEulerAngles = newRot;
        }
    }
}
