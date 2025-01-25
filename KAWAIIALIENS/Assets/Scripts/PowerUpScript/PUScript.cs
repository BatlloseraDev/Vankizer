using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUScript : MonoBehaviour
{
    private Rigidbody2D rb;
    int hp = 6;
    GameObject gameManager;
    int type = 0;
    AudioSource PowerUpSound;
    [SerializeField]
    float fxVolume;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        gameManager = GameObject.FindGameObjectWithTag("GameController");
        rb.linearVelocity = new Vector2(-2f, 0);


        PowerUpSound = gameObject.GetComponent<AudioSource>(); 
        fxVolume = GameObject.FindGameObjectWithTag("GameController").GetComponent<volumenController>().getFxValue();
        PowerUpSound.volume = fxVolume;

        if (gameObject.name== "PU1(Clone)"|| gameObject.name == "PU1")
        {
            type = 1;
        }
        else
        {
            type = 2; 
        }


    }

    // Update is called once per frame
    void Update()
    {
        checkLife();
    }
    void checkLife()
    {
        if (hp <= 0)
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
        if (collision.tag == "playerShip")
        {
            gameManager.GetComponent<GameManager>().type_PU(type);
            PowerUpSound.Play();
            rb.linearVelocity = Vector2.zero;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Destroy(gameObject,2.5f);
        }
    }
}
