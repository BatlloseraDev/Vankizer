using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateStars : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Stars;
    GameObject gameManager;
    float timerSpawn = 1f;
    float MaxX;
    float MaxY;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController");
        MaxX = gameManager.GetComponent<GameManager>().GetSizeX();
        MaxY = gameManager.GetComponent<GameManager>().GetSizeY();
        StartCoroutine(timeSpawner());
        StartCoroutine(spawnerStars());
    }

    IEnumerator spawnerStars()
    {
        while (true)
        {
            aleatoryStars();
            yield return new WaitForSeconds(timerSpawn);
        }
    }
    IEnumerator timeSpawner()
    {
        while (true)
        {
            randomTimer();
            yield return new WaitForSeconds(5);
        }
    }
    void randomTimer()
    {
       timerSpawn= Random.Range(2f, 5f);
    }

    void aleatoryStars()
    {
       
        int maxStars= (int)Random.Range(1, 5);

        for(int i=0; i<maxStars; i++)
        {
            int RandomStar = (int)Random.Range(0f, Stars.Length);
            if (RandomStar == Stars.Length)
            {
                RandomStar -= 1;
            }
            GameObject provisionalStar = Stars[RandomStar];
            float cloneOnX = MaxX + provisionalStar.transform.localScale.x * 2;
            float cloneOnY = Random.Range((-MaxY) + (provisionalStar.transform.localScale.y / 2), MaxY - (provisionalStar.transform.localScale.y / 2));

            Instantiate(provisionalStar, new Vector2(cloneOnX, cloneOnY), Quaternion.identity);
        }

    }

}
