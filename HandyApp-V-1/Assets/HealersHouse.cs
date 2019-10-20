using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealersHouse : MonoBehaviour
{
    public Maneger maneger;
    public TextMeshProUGUI coins;
    public ButtonForE button;
    public int cost;
    public DataManager dataManager;
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
        if(dataManager.data.coins - cost >= 0)
        {
            dataManager.data.coins -= cost;
            Debug.Log(dataManager.data.coins);
            coins.text = dataManager.data.coins.ToString();
        }
        
            
        
        maneger.player1.GetComponent<Health>().Revive(100);
    }
}
