using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static MoveObject.lerpState;

public class UI_Controller : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown function;
    
    public static int functionSelection;
    public int currentStateNum;
    CameraMovement cam;

    public void UpdateDropDownFunction()
    {
        functionSelection = function.value;
    }

    public void rightButtonClick()
    {

        if (currentStateNum == 0 || currentStateNum == 1 || currentStateNum == 2)
        {
            
            CameraMovement.startCamMove(true);
            //updateText(currentState, true);
        }
    }

    public void leftButtonClick()
    {

        if (currentStateNum == 1 || currentStateNum == 2 || currentStateNum == 3)
        {
            //startCamMove(false);
            //updateText(currentState, false);
        }
    }

    private void Start()
    {
        currentStateNum = MoveObject.getStateNum();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
