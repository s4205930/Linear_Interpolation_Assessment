using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraMovement : MonoBehaviour
{

    // Define floats that store the start position of the camera before the lerp and two delta variables for the camera movement and shake
    static float startPos;
    static float endPos;
    static float delta;
    static float deltaS;

    //Defining booleans that are true when an object is lerping so that a lerp cannot be applied whilst the object is already under motion
    public static bool moving;
    public static bool shaking;

    //Define boolean that inducates which direction the camera should lerp when changing objects in view
    static bool moveLR = true;

    private void Start()
    {
        startPos = transform.position.x;
    }


    //Public method that allows the UI_Controller script to activate the coroutine: CamMove();
    public static void startCamMove(bool direction, MonoBehaviour instance)
    {
        instance.StartCoroutine(CamMove(direction));
    }


    //IEnumerator that contains the lerp equation for the camera
    private static IEnumerator CamMove(bool direction)
    {
        if (!moving)
        {
            moving = true;
            moveLR = direction;

            if (moveLR) { endPos = startPos + 20; }
            else { endPos = startPos - 20; }

            float time = 0f;

            while (time <= 1)
            {
                delta = Eases.Other.InOutElastic(time) * 20;
                time += Time.deltaTime;

                yield return new WaitForSeconds(Time.deltaTime);
            }

            startPos = endPos;
            delta = 0;
            moving = false;
        }
    }

    public static void startCamShake(MonoBehaviour instance)
    {
        instance.StartCoroutine(camShake());
    }

    private static IEnumerator camShake()
    {
        float time = 0f;
        shaking = true;

        while (time <= 0.5)
        {
            deltaS = Eases.Trig.Sine(time * 2) * 4;
            time += Time.deltaTime;

            yield return new WaitForSeconds(Time.deltaTime);
        }

        shaking = false;

    }

    private void Update()
    {
        if (moveLR)//Applies the values from the lerp equations to the camera's position according to the previously defined booleans
        {
            transform.position = new Vector3(startPos + delta, 5f, -15f);
        }
        else
        {
            transform.position = new Vector3(startPos - delta, 5f, -15f);
        }

        if (shaking)//Uses Perlin noise to generate smooth random values between -1 and 1 (after the *2 -1). deltaS is changed for x, y, and z so that the camera doesn't move equally in all dimentions
        {
            transform.localPosition = new Vector3(startPos + Mathf.PerlinNoise(0, deltaS) * 2 - 1, 5 + Mathf.PerlinNoise(0, deltaS + 10) * 2 - 1, -15 + Mathf.PerlinNoise(0, deltaS + 20));
        }

    }
}
