using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;


public class AdManeger : MonoBehaviour
{
    // Start is called before the first frame update

    public int becomeCoins;
    public void Show()
    {
        if (Advertisement.IsReady("video"))
        {
            Advertisement.Show("video", new ShowOptions() { resultCallback = HandleAdResult });
        }
    }
    private void HandleAdResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("Ads Finish");
                GetComponent<Coins>().CoinPlus(becomeCoins);
                break;

            case ShowResult.Skipped:
                Debug.Log("Nicht fertig");
                break;

            case ShowResult.Failed:
                Debug.Log("Fail");
                break;
        }
    }
}
