using System.Collections;
using UnityEngine;

public class LerpScript : MonoBehaviour
{
    

    //Defineing an enum to hold the current state so the lerp affects the correct pararmeter
    public enum lerpState
    {
        Translate, Rotate, Scale, Combination
    }
    public static lerpState currentState = lerpState.Translate;



    //Defining lerpVal that will be used in different scripts to apply the lerp to objcets
    public static float lerpVal;



    //Defining two floats that cause the translate lerps to also lerp linearly in the x-axis to better display the curve of the easings
    private float xPos = 0f;
    public static float xPosNew = 0f;



    //Defining boolean that stores if the object is at the end of a lerp or in its start position
    private bool polarity = true;



    //Defining boolean that is true when an object is lerping so that a lerp cannot be applied whilst the object is already under motion
    public static bool moving = false;


        
    

    //Public method that allows the raycasting script to activate the coroutine: Lerp();
    public void startLerp()
    {
        StartCoroutine(Lerp());
    }

   
    //Returns a number that corresponds to the current lerp state
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



    //public method that allow the ui controller to update the current lerp state when buttons are pressed to change the object in frame
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


    //IEnumerator that contains the lerp equation
    private IEnumerator Lerp()
    {

        if (!moving) 
        {
            moving = true;
            float time = 0f;
            xPos = 0f;
            lerpVal = 0;

            while (time <= 1)
            {
                switch (UI_Controller.functionSelection)//Takes value from the drop down menu
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


            //Flips the polarity boolean if the lerp state isnt combination or if the state is combination and atleast one of the toggles is true
            if (currentState == lerpState.Combination && (UI_Controller.tranBool || UI_Controller.rotBool || UI_Controller.scaBool)  ||  currentState != lerpState.Combination)
            {
                polarity = !polarity;
            }
            moving = false;
        }
    }
}
