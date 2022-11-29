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
    public static float lerpVal;
    private float xPos = 0f;
    public static float xPosNew = 0f;
    private bool polarity = true;
    public static bool moving = false;
        
    

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
            lerpVal = 0;

            while (time < 1)
            {
                switch (UI_Controller.functionSelection)
                {
                    case 0:
                        lerpVal = Eases.Linear(time);
                        break;
                    case 1:
                        lerpVal = Eases.Quadratic.In(time);
                        break;
                    case 2:
                        lerpVal = Eases.Quadratic.Out(time);
                        break;
                    case 3:
                        lerpVal = Eases.Quadratic.InOut(time);
                        break;
                    case 4:
                        lerpVal = Eases.Trig.SinIn(time);
                        break;
                    case 5:
                        lerpVal = Eases.Trig.SinOut(time);
                        break;
                    case 6:
                        lerpVal = Eases.Other.InElastic(time);
                        break;
                    case 7:
                        lerpVal = Eases.Other.OutElastic(time);
                        break;
                    case 8:
                        lerpVal = Eases.Other.InOutElastic(time);
                        break;
                 }

                xPos += Time.deltaTime * 10;
                time += Time.deltaTime;

                if (!polarity)
                {
                    lerpVal = 1 - lerpVal;
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
}
