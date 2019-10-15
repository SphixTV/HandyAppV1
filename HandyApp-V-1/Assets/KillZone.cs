using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    public string PlayerTag;
    public Transform SpawnTransform;
    public Transform player;
    void OnTriggerExit(Collider other)
    {
        
        if(other.gameObject.tag == PlayerTag)
        {
            Debug.Log("ExitPlayer");
            player.position = SpawnTransform.position;
        }
    }
    
}
