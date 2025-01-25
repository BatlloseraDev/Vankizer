using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text gameTimerText;
    public Text gameScoreText;
    float gameTimer;
    int seconds;
    int minutes;
    int hours;

    //calculo de pantalla
    float MaxX;
    float MaxY;
    float sideGOX;
    float sideGOY;

    //calculo de puntos
    int puntos = 0;
    [SerializeField]
    private GameObject[] XPs;

    //Cambiar damage bala
    int damage = 2;

    //PUs
    public GameObject powerUp1;
    public Text timerPU1;
    private float cdPU1;
    public GameObject powerUp2;
    public Text timerPU2;
    private float cdPU2;
    public GameObject shield;
    [SerializeField]
    private GameObject[] PUs;

    //score die
    public Text deadTimerText;
    public Text deadScoreText;

    // Start is called before the first frame update
    void Awake()
    {
        var unitsInY = Camera.main.orthographicSize * 2f;
        var unitsInX = unitsInY * ((float)Screen.width / (float)Screen.height);

        MaxX = unitsInX / 2;
        MaxY = unitsInY / 2;

    }

    // Update is called once per frame
    void Update()
    {
        gameTimer += Time.deltaTime ;
        
        seconds = (int)(gameTimer % 60);
        minutes = (int)(gameTimer / 60) % 60;
        hours = (int)(gameTimer / 3600) % 24;

        string timerString = string.Format("{0:0}:{1:00}:{2:00}", hours, minutes, seconds);

        gameTimerText.text = timerString;
        string scoreString = string.Format("Score: {0:000000000}", puntos);
        gameScoreText.text = scoreString;

        Pu1();
        Pu2();
      
    }

    public GameObject[] getPUArray()
    {
        return PUs;
    }

    public GameObject[] getXpArray()
    {
        return XPs;
    }

    public void plusScore(int plus)
    {
        puntos += plus;  
    }


    public int GetSeconds()
    {
        return seconds; 
    }
    public int GetMinutes()
    {
        return minutes; 
    }


    public float GetSizeX()
    {
        return MaxX;
    }

    public float GetSizeY()
    {
        return MaxY; 
    }

    public int get_damage()
    {
        return damage;
    }
   public void type_PU(int tipo)
    {
        if (tipo == 1)
        {
            cdPU1 = 10;
            if (!powerUp1.activeSelf)
            {
                powerUp1.SetActive(true);
            }
        }
        else if (tipo == 2)
        {
            cdPU2 = 15;
            if (!powerUp2.activeSelf)
            {
                powerUp2.SetActive(true);
            }
        }
    }

    void Pu1()
    {
        if (powerUp1.activeSelf)
        {
            if (cdPU1 > 0)
            {
                
                cdPU1 -=  Time.deltaTime;
                damage = 10;
            }
            else if (cdPU1 <= 0)
            {
                damage = 2;
                powerUp1.SetActive(false);
            }
            int cdSeconds = (int)cdPU1;
            string cd_string = string.Format("{0:00}", cdSeconds);
            timerPU1.text = cd_string; 
        }
    }

    void Pu2()
    {
        if (powerUp2.activeSelf)
        {
            if (cdPU2 > 0)
            {
               
                cdPU2 -= Time.deltaTime;
                shield.SetActive(true);
            }
            else if (cdPU2 <= 0)
            {
                shield.SetActive(false);
                powerUp2.SetActive(false);
            }
            int cdSeconds = (int)cdPU2;
            string cd_string = string.Format("{0:00}", cdSeconds);
            timerPU2.text = cd_string;
        }
    }

    public void ScoreAndTimerUpdate()
    {
        deadScoreText.text = gameScoreText.text;
        string timerString = string.Format( "TIME: {0:0}:{1:00}:{2:00}", hours, minutes, seconds );
        deadTimerText.text = timerString;
    }


    public int get_points()
    {
        return puntos; 
    }
}
