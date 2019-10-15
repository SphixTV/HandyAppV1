using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell_Dictonary : MonoBehaviour
{
    public GameObject[] Spells;
    public bool[] SpellActive;


    private void Start()
    {
        
    }
    public GameObject GetGameObject(int number)
    {
        if (SpellActive[number])
        {
            return Spells[number];
        }
        else
        {
            return null;
        }

    }
    public void SetGameObject(int number , bool state)
    {
        if (state)
        {
            SpellActive[number] = state;
        }
        else
        {
            SpellActive[number] = state;
        }

    }
    public string GetNameObject(int number)
    {
        return Spells[number].name;
    }


}
