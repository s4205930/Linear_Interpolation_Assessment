using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static MoveObject.lerpState;

public class UI_Controller : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown function;
    [SerializeField] private TextMeshProUGUI title;

    
    public static int functionSelection;
    public int currentStateNum;

    public void UpdateDropDownFunction()
    {
        functionSelection = function.value;
    }

    public void RightButtonClick()
    {
        currentStateNum = MoveObject.getStateNum();

        if (currentStateNum == 0 || currentStateNum == 1 || currentStateNum == 2)
        {
            CameraMovement.startCamMove(true, this);
            MoveObject.updateState(currentStateNum, true);
            UpdateText();
        }
    }

    public void LeftButtonClick()
    {
        currentStateNum = MoveObject.getStateNum();

        if (currentStateNum == 1 || currentStateNum == 2 || currentStateNum == 3)
        {
            CameraMovement.startCamMove(false, this);
            MoveObject.updateState(currentStateNum, false);
            UpdateText();
        }
    }

    public void shakeClick()
    {
        CameraMovement.startCamShake(this);
    }

    private void UpdateText()
    {
        currentStateNum = MoveObject.getStateNum();

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
                title.SetText("Colour");
                break;
        }
    }

    private void Start()
    {
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
