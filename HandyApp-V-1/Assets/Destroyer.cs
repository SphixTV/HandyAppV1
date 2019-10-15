using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public float time = 5;
    private void Start()
    {
        Destroy(gameObject, time);
    }
}
