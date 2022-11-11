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


    [SerializeField] private float growth = 1f;
    [SerializeField] private Slider progress;
    private float t;
    
    //Public function to call lerp from UI button

    public void startLerp()
    {
        StartCoroutine(Lerp());
    }

    private IEnumerator Lerp()
    {
        float time = 0f;

        while (time < 1)
        {
            t = Eases.Qudratic.InOut(time);

            time += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }    

    void Update()
    {

        transform.localScale = Vector3.one * Mathf.Lerp(1, growth, t);
        float rot = Mathf.InverseLerp(0, 1, t) * 720f;
        transform.localEulerAngles = new Vector3(0f, 0f, rot);
        progress.value = Mathf.InverseLerp(0, 1, t);
        
    }
}
