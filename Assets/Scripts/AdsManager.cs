using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
public class AdsManager : MonoBehaviour
{
    
    void Start()
    {
        Advertisement.Initialize("5578715", testMode: true);
     
    }
    [System.Obsolete]
    public void ShowRewardedAd()
    {
        Debug.Log("Showing Ad");
        if (Advertisement.IsReady("Rewarded_Android"))
        {
          

            var options = new ShowOptions
            {
                resultCallback = HandleShowResult
            };
            Advertisement.Show("Rewarded_Android", options);
            Debug.Log("Checking");
        }
        else
        {
            Debug.Log("Rewarded Ad is not ready yet");
        }
    }
    void HandleShowResult(ShowResult result) 
    {
        switch (result)
        {
            case ShowResult.Finished:
                GameManager.instance.player.diamonds += 100;
                UIManager.instance.playerCoinCountText.text = GameManager.instance.player.diamonds.ToString() + "G";
                UIManager.instance.playerGemCountText.text = GameManager.instance.player.diamonds.ToString() + "G";
                break;
            case ShowResult.Skipped:
                Debug.Log("You skipped the ad no gems for you");
                break;
            case ShowResult.Failed:
                Debug.Log("Ad didn't execute");
                break;
       
        }
    }
}
