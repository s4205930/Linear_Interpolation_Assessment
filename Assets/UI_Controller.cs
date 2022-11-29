using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;

public class UI_Controller : MonoBehaviour
{
    //Defining variables for the UI elements
    [SerializeField] private TMP_Dropdown function;
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] public static GameObject tran;
    [SerializeField] public static GameObject rot;
    [SerializeField] public static GameObject sca;

    //Defining public booleans for the 
    public static bool tranBool;
    public static bool rotBool;
    public static bool scaBool;
    

    
    public static int functionSelection;
    public int currentStateNum;

    public void UpdateDropDownFunction()
    {
        functionSelection = function.value;
    }

    public void UpdateToggleTran(bool tog)
    {
        tranBool = tog;
    }
    public void UpdateToggleRot(bool tog)
    {
        rotBool = tog;
    }
    public void UpdateToggleSca(bool tog)
    {
        scaBool = tog;
    }

    public void RightButtonClick()
    {
        currentStateNum = LerpScript.getStateNum();

        if ((currentStateNum == 0 || currentStateNum == 1 || currentStateNum == 2) && !CameraMovement.moving)
        {
            CameraMovement.startCamMove(true, this);
            LerpScript.updateState(currentStateNum, true);
            UpdateText.UpdateTitle();
        }
    }

    public void LeftButtonClick()
    {
        currentStateNum = LerpScript.getStateNum();

        if ((currentStateNum == 1 || currentStateNum == 2 || currentStateNum == 3) && !CameraMovement.moving)
        {
            CameraMovement.startCamMove(false, this);
            LerpScript.updateState(currentStateNum, false);
            UpdateText.UpdateTitle();
            
        }
    }

    public void shakeClick()
    {
        CameraMovement.startCamShake(this);
    }

    private void Start()
    {
        UpdateText.UpdateTitle();
        UpdateDropDownFunction();
    }
}
