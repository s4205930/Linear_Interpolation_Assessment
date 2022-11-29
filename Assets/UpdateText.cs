using UnityEngine;
using TMPro;

public class UpdateText : MonoBehaviour
{
    private static TextMeshProUGUI title;
    void Start()
    {
        //Gets the object the script is attached to and applies it to the title variable
        title = gameObject.GetComponent<TextMeshProUGUI>();
        
    }

    //Public method that allows other scripts to change the title when the camera moves
    public static void UpdateTitle()
    {
        int currentStateNum = LerpScript.getStateNum();

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
