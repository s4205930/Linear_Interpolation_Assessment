using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraMovement : MonoBehaviour
{

    static float startPos;
    static float endPos;
    static float delta;
    static bool moving;
    static bool moveLR;

    private void Start()
    {
        startPos = transform.position.x;
    }

    public static void startCamMove(bool direction)
    {
        camMove(direction);
    }

    private static IEnumerator camMove(bool direction)
    {
        if (!moving)
        {
            moving = true;
            moveLR = direction;

            if (moveLR) { endPos = startPos + 20; }
            else { startPos = startPos - 20; }

            float time = 0f;

            while (time <= 1)
            {
                delta = Eases.Other.InOutElastic(time) * 20;
                time += Time.deltaTime;

                yield return new WaitForSeconds(Time.deltaTime);
            }

            startPos = endPos;
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

    }

    public void shake()
    {

        transform.localPosition += new Vector3(Mathf.PerlinNoise(0, Time.time) * 2 - 1,
            Mathf.PerlinNoise(0, Time.time) * 2 - 1,
            Mathf.PerlinNoise(0, Time.time) * 2 - 1) * 0.5f;

    }
}
