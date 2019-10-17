using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public TMP_InputField playerName;

    public TextMeshProUGUI coins;

    public DataManager dataManager;

    private void Start()
    {
        dataManager.Load();
        playerName.text = dataManager.data.name;
        coins.text = dataManager.data.coins.ToString();
    }
    public void ClickCoin()
    {
        dataManager.data.coins += 1;
        coins.text = dataManager.data.coins.ToString();
    }
    public void ClickCoinMinus()
    {
        dataManager.data.coins -= 1;
        coins.text = dataManager.data.coins.ToString();
    }
    public void ChangeName(string text)
    {

        dataManager.data.name = text;
    }
    public void ClickSave()
    {
        dataManager.Save();
    }
}
