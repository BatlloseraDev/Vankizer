using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hpShootNave : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject naveObject;
    private int hp = 0;
    private GameObject[] lifes;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public GameObject shield;
    AudioSource hitSound;
    float fxvolume;

    [SerializeField]
    GameObject DieScreen; 



    void Start()
    {
        naveObject = GameObject.FindGameObjectWithTag("playerShip");
        hitSound = naveObject.GetComponent<AudioSource>();
       

        if (lifes== null)
        {
            lifes = GameObject.FindGameObjectsWithTag("life");
        
        }
       

    }

    // Update is called once per frame
    void Update()
    {
       
      


    }

    public void lessHp()
    {
        checkVolume();
        if (hp < 3 && !shield.activeSelf)
        {
            hitSound.Play();
            lifes[hp].SetActive(false);
            hp += 1;
        }
        if (hp >= 3)
        {
            gameObject.GetComponent<GameManager>().ScoreAndTimerUpdate();
            DieScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void AddHp()
    {
        hp = 2;
        lifes[hp].SetActive(true);
        Time.timeScale = 1;
        DieScreen.SetActive(false);
    }

    void checkVolume()
    {
        fxvolume = gameObject.GetComponent<volumenController>().getFxValue();
        hitSound.volume = fxvolume; 
    }

    public void shootShip()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

}
