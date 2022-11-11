using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CustomLerp : MonoBehaviour
{

    [SerializeField] private CanvasGroup panel;
    private TextMeshProUGUI objectText;
    bool lerping;
    float lerpFloat;
    float xPos;

    public float dist = 10f;

    

    public void StartLerp()
    {

        if (!lerping)
        {
            StartCoroutine(LerpFloat());
        }

    }

    IEnumerator LerpFloat()
    {
        lerping = true;
        xPos = 0f;
        float time = 0;

        while (time < 1)
        {
            float perc = 0;

            perc = Eases.Other.InOutElastic(time);

            lerpFloat = Lerps(0, dist, perc);
            xPos += (Time.deltaTime * dist);
            
            time += Time.deltaTime;

            yield return null;
        }
        lerping = false;
    }

    public static float Lerps(float startValue, float endValue, float t)
    {
        return (startValue + (endValue - startValue) * t);
    }

    
    void Update()
    {

        transform.position = new Vector3(xPos, lerpFloat, 0f);
               
    }
}
