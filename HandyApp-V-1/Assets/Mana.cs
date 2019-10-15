using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Mana : MonoBehaviour
{
    [Range(0, 100)]
    [SerializeField] public float mana;
    
    [SerializeField] public float ManaRegenationTime;
    [SerializeField] public float ManaRegenation;
    [SerializeField] private Slider slider;
   
    
    private void Start()
    {
        slider.value = mana / 100;
        StartCoroutine(Wait());
    }
    public void ManaCost(float Damage)
    {

        
        if (mana - Damage <= 0)
        {
            

        }
        else
        {
            mana -= Damage;
            slider.value = mana / 100;

        }

    }
    public void AddMana(float healthRev)
    {
        if (mana + healthRev > 100)
        {
            mana = 100;
        }
        else
        {
            mana += healthRev;

        }
        slider.value = mana / 100;

    }
    IEnumerator Wait()
    {
        while(true){
            yield return new WaitForSeconds(ManaRegenationTime);
            AddMana(ManaRegenation);
        }
        
        
    }
}
