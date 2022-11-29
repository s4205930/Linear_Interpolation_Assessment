using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraMovement : MonoBehaviour
{

    static float startPos;
    static float endPos;
    static float delta;
    static float deltaS;
    public static bool moving;
    public static bool shaking;
    static bool moveLR = true;

    private void Start()
    {
        startPos = transform.position.x;
    }

    public static void startCamMove(bool direction, MonoBehaviour instance)
    {
        instance.StartCoroutine(camMove(direction));
    }

    private static IEnumerator camMove(bool direction)
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

    private void Update()
    {
        if (moveLR)
        {
            transform.position = new Vector3(startPos + delta, 5f, -15f);
        }
        else
        {
            transform.position = new Vector3(startPos - delta, 5f, -15f);
        }

        if (shaking)
        {
            transform.localPosition = new Vector3(startPos + Mathf.PerlinNoise(0, deltaS) * 2 - 1, 5 + Mathf.PerlinNoise(0, deltaS + 10) * 2 - 1, -15 + Mathf.PerlinNoise(0, deltaS + 20));
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
}
