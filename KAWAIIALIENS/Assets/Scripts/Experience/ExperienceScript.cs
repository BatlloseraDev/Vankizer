using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceScript : MonoBehaviour
{
    private Rigidbody2D rb;
    int hp = 6;
    GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        gameManager= GameObject.FindGameObjectWithTag("GameController");
        rb.linearVelocity = new Vector2(-2f, 0);
    }

    void Update()
    {
        checkLife();
    }

    void checkLife()
    {
        if(hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void lessHp(int damage)
    {
        hp -= damage; 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag== "playerShip")
        {
            plusScoreOnGamemanager();
            Destroy(gameObject); 
        }
    }


    void plusScoreOnGamemanager()
    {
        if (gameObject.name == "XP_1(Clone)")
        {
            gameManager.GetComponent<GameManager>().plusScore(100);
        }
        else if (gameObject.name == "XP_2(Clone)")
        {
            gameManager.GetComponent<GameManager>().plusScore(250);
        }
        else if (gameObject.name == "XP_3(Clone)")
        {
            gameManager.GetComponent<GameManager>().plusScore(500);
        }
    }

}
