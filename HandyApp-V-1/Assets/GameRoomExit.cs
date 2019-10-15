using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRoomExit : MonoBehaviour
{
    public Maneger maneger;
    public Transform respawn;
     void OnTriggerExit(Collider other)
    {
        
        if(other.gameObject.name == maneger.player1.name)
        {
            
            maneger.player1.GetComponent<Health>().Damage(1000);
        }

    }
}
