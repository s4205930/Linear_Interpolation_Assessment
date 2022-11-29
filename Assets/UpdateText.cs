using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateText : MonoBehaviour
{
    private static TextMeshProUGUI title;
    void Start()
    {
        title = gameObject.GetComponent<TMPro.TextMeshProUGUI>();
        
    }

    public static void UpdateTitle()
    {
        int currentStateNum = MoveObject.getStateNum();

        switch (currentStateNum)
        {
            case 0:
                title.SetText("Translate");
                break;
            case 1:
                title.SetText("Rotate");
                break;
            case 2:
                title.SetText("Scale");
                break;
            case 3:
                title.SetText("Combination");
                break;
        }
    }
}
