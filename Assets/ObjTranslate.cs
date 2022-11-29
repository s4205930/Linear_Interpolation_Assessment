using UnityEngine;

public class ObjTranslate : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 newPos;

    private void Start()
    {
        //Initialise the start position of the object
        startPos = transform.position;
    }

    void Update()
    {
        //update the position of the object using the lerp val if the lerpstate is translate
        if (LerpScript.currentState == LerpScript.lerpState.Translate)
        {
            newPos.x = startPos.x + LerpScript.xPosNew;
            newPos.y = startPos.y + LerpScript.lerpVal * 10;
            newPos.z = startPos.z;
            transform.position = newPos;
        }
    }
}
