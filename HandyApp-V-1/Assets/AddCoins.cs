using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCoins : MonoBehaviour
{
    public int Coins;
    public Maneger maneger;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == maneger.player1.name)
        {
            GetComponent<Coins>().CoinPlus(Coins);
            Destroy(gameObject);
        }

    }

}
