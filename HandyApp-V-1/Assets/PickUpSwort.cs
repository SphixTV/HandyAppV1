using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSwort : MonoBehaviour
{
    public Maneger maneger;
    public ButtonForE button;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == maneger.player1.name)
        {
            button.Disable(true);
            if (button.pressed)
            {
                button.ResetBool();
                PickUp();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == maneger.player1.name)
        {
            button.Disable(false);
        }
    }
    public void PickUp()
    {
        Debug.Log("SwortIsDa");
    }
}
