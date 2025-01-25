using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PointsAndStats : MonoBehaviour
{
    private float musicVolume;
    private float fxVolume;
    private int score;

    private string musicPrefsName = "MusicVolume";
    private string fxPrefsName = "FxVolume";
    private string scorePrefsName = "Score";

    public Text scoreText;
    public  Slider musicValue;
    public Slider fxValue; 

    private void Awake()
    {
       
        LoadData();
     
    }

    // Start is called before the first frame update
    void Start()
    {
        ActualizarScoreAndValues();
       // Debug.Log(musicVolume);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Set_score ()
    {
        int puntuacion = gameObject.GetComponent<GameManager>().get_points();
        score = puntuacion; 
    }

    void ActualizarScoreAndValues()
    {
       
        string ScoreString = string.Format("HI: {0:000000000}", score);
        scoreText.text = ScoreString;
        musicValue.value = musicVolume;
        fxValue.value = fxVolume;  
      
    }




    private void OnDestroy()
    {
        SaveData(); 
    }

    public void SaveOnlyMusic()
    {
        musicVolume = musicValue.value;
        fxVolume = fxValue.value; 
        PlayerPrefs.SetFloat(musicPrefsName, musicVolume);
        PlayerPrefs.SetFloat(fxPrefsName, fxVolume);
       
    }

    public void SaveData()
    {
        PlayerPrefs.SetFloat(musicPrefsName, musicVolume);
        PlayerPrefs.SetFloat(fxPrefsName, fxVolume);
        if(score > PlayerPrefs.GetInt(scorePrefsName)) PlayerPrefs.SetInt(scorePrefsName, score);


    }

    public void LoadData()
    {
        musicVolume = PlayerPrefs.GetFloat(musicPrefsName, 1f);
        fxVolume = PlayerPrefs.GetFloat(fxPrefsName, 1f);
        score = PlayerPrefs.GetInt(scorePrefsName,0);

    }
    public float get_FxValue()
    {
        return fxVolume;
    }

    public float get_MusicValue()
    {
        return musicVolume; 
    }
}
