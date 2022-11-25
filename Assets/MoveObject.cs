using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveObject : MonoBehaviour
{
    /// <summary>
    /// This script should be added onto an object and use a ui button to start the lerp
    /// and a slider to indicate the progress of the lerp
    /// </summary>


    
    [SerializeField] private Slider progress;
    public enum lerpState
    {
        Translate, Rotate, Scale, Colour
    }
    lerpState currentState = lerpState.Translate;
    private float t;
    private float xPos = 0f;
    
    

    public void startLerp()
    {
        StartCoroutine(Lerp());
    }

    private IEnumerator Lerp()
    {
        float time = 0f;
        xPos = 0f;

        while (time < 1)
        {
            t = Eases.Quadratic.InOut(time);

            xPos += Time.deltaTime * 10;
            time += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }

        
    }    

    void Update()
    {        

        if (currentState == lerpState.Translate)
        {
            transform.localPosition = new Vector3(xPos, t * 10, 0f);
        }
        else if (currentState == lerpState.Rotate)
        {
            float rot = Mathf.InverseLerp(0, 1, t) * 720f;
            transform.localEulerAngles = new Vector3(0f, 0f, rot);
        }
        else if (currentState == lerpState.Scale)
        {
            transform.localScale = Vector3.one * Mathf.Lerp(1, 3, t);
        }
    }
}
