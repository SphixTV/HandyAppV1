using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{

    [Range(0, 100)]
    [SerializeField] private float damege;
    public Maneger maneger;
    public bool inspike;
    GameObject player;
    Health health;
    public void Start()
    {
        health = maneger.player1.GetComponent<Health>();

    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == maneger.player1.name)
        {
            inspike = true;
            player = other.gameObject;
            StartCoroutine(BecomeDamage());
            
        }
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.name == maneger.player1.name)
        {
            inspike = false;
        }
    }

    IEnumerator BecomeDamage()
    {
        while (inspike == true && health.health - damege / health.protection > 0)

        {
            player.GetComponent<Health>().Damage(damege);
            yield return new WaitForSeconds(1F);
        }
        if(inspike == true && health.health - damege / health.protection <= 0)
        {
            player.GetComponent<Health>().Damage(damege);
            inspike = false;
        }
        

        
    }
      
    

}
