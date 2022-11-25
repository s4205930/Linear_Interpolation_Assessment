using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static MoveObject.lerpState;

public class UI_Controller : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown function;
    public static int functionSelection;

    public void UpdateDropDownFunction()
    {
        functionSelection = function.value;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
