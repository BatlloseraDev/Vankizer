using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
/*
public class RewardedAdsButton : MonoBehaviour, IUnityAdsListener
{
    public string googleId = "3980411";
    public string myPlacementId = "rewardedVideo";

    
    Button myButton;

    int timesRewarded = 0; 


    // Start is called before the first frame update
    void Start()
    {
        myButton = GetComponent<Button>();

        // Set interactivity to be dependent on the Placement’s status:
        myButton.interactable = Advertisement.IsReady(myPlacementId);

        if (myButton) myButton.onClick.AddListener(ShowRewardedVideo);
        Advertisement.AddListener(this);
        Advertisement.Initialize(googleId, false);


    }

    void ShowRewardedVideo()
    {
        Advertisement.Show(myPlacementId);
    }

    public void OnUnityAdsReady(string placementId)
    {
        // If the ready Placement is rewarded, activate the button: 
        if (placementId == myPlacementId && timesRewarded<2)
        {
            myButton.interactable = true;
        }
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished)
        {
           GameObject gameManager = GameObject.FindGameObjectWithTag("GameController");
           gameManager.GetComponent<hpShootNave>().AddHp();
            timesRewarded++;

            if(timesRewarded>=2) myButton.interactable = false;

        }
        else if (showResult == ShowResult.Skipped)
        {
            // Do not reward the user for skipping the ad.
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.LogWarning("The ad did not finish due to an error.");
        }
    }
    public void OnUnityAdsDidError(string message)
    {
        // Log the error.
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        // Optional actions to take when the end-users triggers an ad.
    }



   
}*/
