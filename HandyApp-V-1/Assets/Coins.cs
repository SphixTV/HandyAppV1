using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Coins : MonoBehaviour
{


    public TextMeshProUGUI coins;

    public DataManager dataManager;

    private void Start()
    {
        dataManager.Load("player.json");

        coins.text = dataManager.data.coins.ToString();
    }

    public void CoinPlus(int coin)
    {
        dataManager.data.coins += coin;
        coins.text = dataManager.data.coins.ToString();
    }
    public void CoinMinus(int coin)
    {
        dataManager.data.coins -= coin;
        coins.text = dataManager.data.coins.ToString();
    }
    



}


    