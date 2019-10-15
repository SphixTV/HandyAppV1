using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell_Attack : MonoBehaviour
{
    public Spell_Dictonary spell_Dictonary;
    public int Spell;
    public float Speed;
    public Transform shootPoint;
    public float TimeBetweenActions;
    public float manacost;
    bool time = true;
    Mana mana;


    private void Start()
    {
        mana = GetComponent<Mana>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && time)
        {
            attack();

        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(TimeBetweenActions);
        time = true;
    }
    void attack()
    {
        if (mana.mana - manacost < 0)
        {

        }
        else
        {
            time = false;
            mana.ManaCost(manacost);
            var SpellObject = Instantiate(spell_Dictonary.GetGameObject(Spell), shootPoint.position, transform.rotation);
            SpellObject.GetComponent<Rigidbody>().AddForce(transform.forward * Speed);
            StartCoroutine(Wait());
        }
    }
    public void attackTrigger()
    {
        if (time)
        {
            attack();
        }
    }
}
