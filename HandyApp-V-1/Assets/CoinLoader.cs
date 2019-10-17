using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[System.Serializable]
public class CoinLoader : MonoBehaviour
{

    public int Coins;
    
    public TextMeshProUGUI coinsText;

    public int coinsPlus;
    public bool coinsplus;
    
    public void Start()
    {

        LoadKeys();
        
        StartCoroutine(coinsave());
    }
    public IEnumerator coinsave()
    {
        while (true)
        {
            LoadKeys();
            

            

            yield return new WaitForSeconds(1);
            SaveKeys();

        }

    }
    public void SaveKeys()
    {
        
        SaveSystem.SavePlayer(this);

    }
    public void LoadKeys()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        Coins = data.Coins;
        coinsText.text = data.Coins.ToString();
        return;


    }
    public void Update()
    {
        if (coinsplus)
        {
            coinsplus = false;
            Coins += coinsPlus;
        }
    }

}
