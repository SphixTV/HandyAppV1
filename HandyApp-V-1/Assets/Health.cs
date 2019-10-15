using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [Range(0, 100)]
    [SerializeField] public float health;
    [Range(0, 10)]
    [SerializeField] public float protection;
    [SerializeField] private Slider slider;
    [SerializeField] private Transform respawn;
    private Animator Animator;
    [SerializeField] private GameObject UIPanelJoystick;
    private Moving moving;
    private void Start()
    {
        slider.value = health / 100;
        Animator = GetComponent<Animator>();
        moving = GetComponent<Moving>();
    }
    public void Damage(float Damage)
    {

        Damage = Damage / protection;
        if(health - Damage <= 0)
        {
            //TOT
            moving.NoMove = true;
            
           gameObject.GetComponent<Moving>().enabled = false;
           gameObject.GetComponent<CharacterController>().enabled = false;
           gameObject.transform.position = respawn.transform.position;
           gameObject.GetComponent<CharacterController>().enabled = true;
           gameObject.GetComponent<Moving>().enabled = true;
            //Animator.SetBool("die", true);
            Debug.Log("TooT");
            slider.value = 0 / 100;
            health = 0;
            Revive(100);
            
        }
        else
        {
            health -= Damage;
            slider.value = health / 100;
           
        }
        
    }
    public void Revive(float healthRev)
    {
        if(health + healthRev > 100)
        {
            health = 100;
        }
        else
        {
        health += healthRev;
        
        }
        slider.value = health / 100;
        
    }
    
}
