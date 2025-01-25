using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class BannerAdScript : MonoBehaviour
{

    public string googleId = "3980411";
    public string placementId = "PauseAdd";
    public bool testMode = false;


    void Start()
    {
        Advertisement.Initialize(googleId, testMode);
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
    }

    // Update is called once per frame
   

    IEnumerator ShowBannerWhenInitialized()
    {
        while (!Advertisement.isInitialized)
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.Show(placementId);

      
    }

    public void StartAdCoroutine()
    {
        StartCoroutine(ShowBannerWhenInitialized());
    }
    public void StopAdCoroutine()
    {
        StopCoroutine(ShowBannerWhenInitialized());
        Advertisement.Banner.Hide(false);
  
    }

}
