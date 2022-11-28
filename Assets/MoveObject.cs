using System.Collections;
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
    public static lerpState currentState = lerpState.Translate;
    private float t;
    private float xPos = 0f;
    private float xPosNew = 0f;
    private float dist = 10f;
    private bool polarity = true;
    private bool moving = false;
    private Vector3 startPos;
    private Vector3 newPos;
    
    

    public void startLerp()
    {
        StartCoroutine(Lerp());
    }

   

    public static int getStateNum()
    {
        switch (currentState)
        {
            case lerpState.Translate:
                return 0;
            case lerpState.Rotate:
                return 1;
            case lerpState.Scale:
                return 2;
            case lerpState.Colour:
                return 3;
            default:
                return 4;
        }
    }

    private IEnumerator Lerp()
    {

        if (!moving)
        {
            moving = true;
            float time = 0f;
            xPos = 0f;

            while (time < 1)
            {
                //t = Eases.Custom.test(time);

                switch (UI_Controller.functionSelection)
                {
                    case 0:
                        t = Eases.Linear(time);
                        break;
                    case 1:
                        t = Eases.Quadratic.In(time);
                        break;
                    case 2:
                        t = Eases.Quadratic.Out(time);
                        break;
                    case 3:
                        t = Eases.Quadratic.InOut(time);
                        break;
                    case 4:
                        t = Eases.Trig.SinIn(time);
                        break;
                    case 5:
                        t = Eases.Trig.SinOut(time);
                        break;
                    case 6:
                        t = Eases.Other.InElastic(time);
                        break;
                    case 7:
                        t = Eases.Other.OutElastic(time);
                        break;
                    case 8:
                        t = Eases.Other.InOutElastic(time);
                        break;

                }

                xPos += Time.deltaTime * 10;
                time += Time.deltaTime;

                if (!polarity)
                {
                    t = 1 - t;
                    xPosNew = 10 - xPos;
                }
                else { xPosNew = xPos; }

                yield return new WaitForSeconds(Time.deltaTime);
            }

            polarity = !polarity;
            moving = false;
        }

        

        
    }

    private void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {        

        if (currentState == lerpState.Translate)
        {
            //newPos = startPos + new Vector3(xPosNew, t * dist, 0f);
            newPos.x = startPos.x + xPosNew;
            newPos.y = startPos.y + t * dist;
            newPos.z = startPos.z;
            //transform.position = new Vector3(xPosNew, t * dist, 0f);
            transform.position = newPos;
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
