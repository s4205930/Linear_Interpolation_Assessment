using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static LerpScript.lerpState;
using UnityEditor;

public class UI_Controller : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown function;
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] public static GameObject tran;
    [SerializeField] public static GameObject rot;
    [SerializeField] public static GameObject sca;
    public static bool tranBool;
    public static bool rotBool;
    public static bool scaBool;
    

    
    public static int functionSelection;
    public int currentStateNum;

    private void UpdateDropDownFunction()
    {
        functionSelection = function.value;
    }

    private void UpdateToggleTran(bool tog)
    {
        tranBool = tog;
    }
    private void UpdateToggleRot(bool tog)
    {
        rotBool = tog;
    }
    private void UpdateToggleSca(bool tog)
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
    }
}
