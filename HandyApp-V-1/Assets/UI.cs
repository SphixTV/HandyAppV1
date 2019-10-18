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
        dataManager.Load("player.json");
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
        dataManager.Save(playerName.text + "."+playerName.text);
    }
    public void ClickLoad()
    {
        dataManager.Load(playerName.text +"."+ playerName.text);
        coins.text = dataManager.data.coins.ToString();
        playerName.text = dataManager.data.name;
    }
}
