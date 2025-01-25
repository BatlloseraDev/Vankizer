using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class volumenController : MonoBehaviour
{
    [SerializeField]
    private GameObject ActiveOptions;
    [SerializeField]
    private GameObject MusicOptions;
    [SerializeField]
    private GameObject FxOptions;

    private float musicValue;
    private float fxValue;



    
    private AudioSource Song;
    private void Awake()
    {
        Song = gameObject.GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {/*
        Transform Music = ActiveOptions.transform.Find("MusicSlider");
        MusicOptions = Music.gameObject;

        Transform Fx= ActiveOptions.transform.Find("FxSlider");
        FxOptions = Fx.gameObject;
        */
        

        musicValue = 1;
        fxValue = 1;
        Song.volume = musicValue;

    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void songVolume()
    {

       

      musicValue = MusicOptions.GetComponent<Slider>().value;
       
      Song.volume = musicValue;

    }
    public void fx()
    {
        fxValue = FxOptions.GetComponent<Slider>().value;
    }
    
  
    public float getFxValue()
    {
        return fxValue;
    }




   
}
