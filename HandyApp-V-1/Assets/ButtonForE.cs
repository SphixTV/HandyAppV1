using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonForE : MonoBehaviour
{
    public bool pressed;
    
    public GameObject buttonForE;
    
    public void Disable(bool DisableBool)
    {
        buttonForE.SetActive(DisableBool);
        if (!DisableBool)
        {
            pressed = false;
        }
    }
    public void PressButton(bool pressedBool)
    {
        pressed = pressedBool;
    }
    public void ResetBool()
    {
        pressed = false;
    }

}


