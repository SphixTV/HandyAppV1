using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManeger : MonoBehaviour
{
    private static BackgroundManeger instance;
   
    void Awake()
    {
        if (instance == null)
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
