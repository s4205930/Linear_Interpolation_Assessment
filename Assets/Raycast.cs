using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Raycast : MonoBehaviour
{
    [SerializeField] private CanvasGroup panel;
    private TextMeshProUGUI objectText;

    
    void Start()
    {

        if (panel != null)
        {
            objectText = panel.gameObject.GetComponentInChildren<TextMeshProUGUI>();
        }
        
    }

    // Update is called once per frame
    void Update()
    { 

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.DrawLine(ray.origin, hit.point, Color.red, 5f);
                if (hit.transform.TryGetComponent(out MoveObject mo)) { 
                    mo.startLerp();
                    StartCoroutine(RevealPanel());
                    objectText.text = "Name: " + hit.transform.name + " \nEasing = TBD" + "\nReturns? + t/f";
                }
                else
                {
                    StartCoroutine(HidePanel());
                }
            }
        }else if (Input.GetMouseButtonDown(1))
        {
            //CameraShake & ObjectReset
        }

    }

    private IEnumerator RevealPanel()
    {
        float time = 0f;
        while (time < 1)
        {
            panel.alpha = Eases.Linear(time);
            time += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }

    private IEnumerator HidePanel()
    {
        float time = 0f;
        while (time < 1)
        {
            panel.alpha = 1 - Eases.Linear(time);
            time += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}
