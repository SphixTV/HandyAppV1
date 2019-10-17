using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerData
{
    public int Coins = 123;


    public PlayerData(CoinLoader coinLoader)
    {
        Coins = coinLoader.Coins;
       
        
}
}
