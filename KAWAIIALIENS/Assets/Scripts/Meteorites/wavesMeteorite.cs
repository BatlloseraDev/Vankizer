using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wavesMeteorite : MonoBehaviour
{
   

    [SerializeField]
    private GameObject[] meteorites;

    int seconds;
    int minutes;
    GameObject gameManager;
    float SpawnTimer = 5;


    // Start is called before the first frame update

    void Start()
    {

        StartCoroutine(SpwanMeteorites());
        gameManager = GameObject.FindGameObjectWithTag("GameController");
 
        StartCoroutine(checkCoroutine());

    }

    // Update is called once per frame
    void Update()
    {
        ChangeTimerSpawn();


    }

    void ChangeTimerSpawn()
    {
        if((seconds >= 30) && (minutes <= 00))
        {
            SpawnTimer = 4f;
        }
        else if (minutes >= 01 && minutes < 3)
        {
            SpawnTimer = 3.5f; 
        }
        else if ((minutes >= 3) && (minutes < 05))
        {
            SpawnTimer = 3f; 
        }
        else if ((minutes >= 05) && (minutes <7))
        {
            SpawnTimer = 2f; 
        }
        else if (minutes >= 7)
        {
            SpawnTimer = 1.5f;
        }
    }


    void CheckTimer()
    {
        seconds = gameManager.GetComponent<GameManager>().GetSeconds();
        minutes = gameManager.GetComponent<GameManager>().GetMinutes();
    }
    IEnumerator checkCoroutine()
    {
        while (true)
        {
            CheckTimer();
            yield return new WaitForSeconds(1);
        }
    }

    IEnumerator SpwanMeteorites()
    {
        while (true)
        {
            SelectionOfMeteorite();
            yield return new WaitForSeconds(SpawnTimer);
        }
    }
   
    void SelectionOfMeteorite()
    {
       
        var unitsInY = Camera.main.orthographicSize * 2f;
        var unitsInX = unitsInY * ((float)Screen.width / (float)Screen.height);

        float MaxX = unitsInX / 2;
        float MaxY = unitsInY / 2;



        int RandomMeteorite = (int)Random.Range(0f, meteorites.Length);
        if(RandomMeteorite == meteorites.Length)
        {
            RandomMeteorite -= 1;
        }
        GameObject provisionalMeteorite = meteorites[RandomMeteorite];
        float cloneOnX = MaxX + provisionalMeteorite.transform.localScale.x*2;
        float cloneOnY = Random.Range((-MaxY) + (provisionalMeteorite.transform.localScale.y / 2), MaxY - (provisionalMeteorite.transform.localScale.y / 2));

        Instantiate(provisionalMeteorite, new Vector2(cloneOnX, cloneOnY ), Quaternion.identity);

    }
}
