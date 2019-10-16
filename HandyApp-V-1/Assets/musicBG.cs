using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicBG : MonoBehaviour
{
    private static musicBG instance;
     void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
