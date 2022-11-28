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
    public static bool moving;
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
                delta = Eases.Quadratic.InOut(time) * 20;
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

    }

    public void shake()
    {

        transform.localPosition += new Vector3(
            Mathf.PerlinNoise(0, Time.time) * 2 - 1,
            Mathf.PerlinNoise(0, Time.time) * 2 - 1,
            Mathf.PerlinNoise(0, Time.time) * 2 - 1) * 0.5f;

    }
}
