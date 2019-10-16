using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealersHouse : MonoBehaviour
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
                ReviveButton();
            }else if (Input.GetKeyDown(KeyCode.E))
            {
                button.ResetBool();
                ReviveButton();
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
    public void ReviveButton()
    {
        maneger.player1.GetComponent<Health>().Revive(100);
    }
}
