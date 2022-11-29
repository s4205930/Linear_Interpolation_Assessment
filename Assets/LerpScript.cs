using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class LerpScript : MonoBehaviour
{
    
    public enum lerpState
    {
        Translate, Rotate, Scale, Combination
    }
    [SerializeField] public static lerpState currentState = lerpState.Translate;
    public static float t;
    private float xPos = 0f;
    private float xPosNew = 0f;
    private float dist = 10f;
    private bool polarity = true;
    public static bool moving = false;
    private Vector3 startPos;
    private Vector3 newPos;
    private Vector3 startRot;
    private Vector3 newRot;    
    

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
            case lerpState.Combination:
                return 3;
            default:
                return 4;
        }
    }

    public static void updateState(int current, bool change)
    {
        t = 0;

        if (change)
        {
            current++;
        }
        else
        {
            current--;
        }

        switch (current)
        {
            case 0:
                currentState = lerpState.Translate;
                break;
            case 1:
                currentState = lerpState.Rotate;
                break;
            case 2:
                currentState = lerpState.Scale;
                break;
            case 3:
                currentState = lerpState.Combination;
                break;
        }

        
    }

    private IEnumerator Lerp()
    {

        if (!moving)
        {
            moving = true;
            float time = 0f;
            xPos = 0f;
            t = 0;

            while (time < 1)
            {
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

            if ((currentState == lerpState.Combination && UI_Controller.tranBool || UI_Controller.rotBool || UI_Controller.scaBool)  ||  currentState != lerpState.Combination)
            {
                polarity = !polarity;
            }
            moving = false;
        }

        

        
    }

    private void Start()
    {
        startPos = transform.position;
        startRot = transform.localEulerAngles;
    }

    void Update()
    {        

        if (currentState == lerpState.Translate)
        {
            newPos.x = startPos.x + xPosNew;
            newPos.y = startPos.y + t * dist;
            newPos.z = startPos.z;
            transform.position = newPos;
        }
        else if (currentState == lerpState.Rotate)
        {
            newRot.z = startRot.z + (-t * 360);
            transform.localEulerAngles = newRot;
        }
        else if (currentState == lerpState.Scale)
        {
            transform.localScale = Vector3.one * (t + 1) * 3;
        }
        else if (currentState == lerpState.Combination)
        {
            if (UI_Controller.tranBool)
            {
                newPos.x = startPos.x + xPosNew;
                newPos.y = startPos.y + t * dist;
                newPos.z = startPos.z;
                transform.position = newPos;
            }
            else
            {
                transform.position = new Vector3(startPos.x + 5, startPos.y + 5, startPos.z);
            }
            if (UI_Controller.rotBool)
            {
                newRot.z = startRot.z + (-t * 360);
                transform.localEulerAngles = newRot;
            }
            if (UI_Controller.scaBool)
            {
                transform.localScale = Vector3.one * (t + 1) * 2;
            }
        }
    }
}
