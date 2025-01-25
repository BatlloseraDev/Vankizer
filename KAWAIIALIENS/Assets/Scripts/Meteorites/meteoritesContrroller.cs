using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteoritesContrroller : MonoBehaviour
{
    [SerializeField]
    private int hp = 10;
    private float timeDestruction = 10f;

    private Rigidbody2D rb;

    int seconds;
    int minutes;
    GameObject gameManager;
    float MaxX;
    float MaxY;
    float sideGOY=0f;
    bool type2 = false;
    float velocityY = 0f;
    float velocityX = 0f;
    bool dieOneTime = false;
    AudioSource explosion;
    float fxVolume;
    //experiencia / score
   
    private GameObject[] XPs;
    [SerializeField]
    private GameObject[] PUs; 
    int xpType = 0;

    //PowerUps

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        gameManager = GameObject.FindGameObjectWithTag("GameController");

        //audio
        fxVolume = gameManager.GetComponent<volumenController>().getFxValue();
        explosion = gameObject.GetComponent<AudioSource>();
        explosion.volume = fxVolume;
        //meteorite
        StartCoroutine(checkCoroutine());
        MaxX = gameManager.GetComponent<GameManager>().GetSizeX();
        MaxY = gameManager.GetComponent<GameManager>().GetSizeY();
        rb.linearVelocity = new Vector2(-2f, 0);
        differentStartMeteorites();
       
        XPs = gameManager.GetComponent<GameManager>().getXpArray();
        PUs = gameManager.GetComponent<GameManager>().getPUArray();

        
        

    }

    // Update is called once per frame
    void Update()
    {
        if (!dieOneTime)
        {
            meteoriteType2();
        }
    
        die();
    }

    void differentStartMeteorites()
    {

        if (gameObject.name == "Meteorite1(Clone)")
        {
            meteoriteType1(0f);
            xpType = 1;
           
        }
        else if (gameObject.name == "Meteorite4(Clone)")
        {
            meteoriteType1(2f);
            xpType = 2;
           
        }
        else if (gameObject.name == "Meteorite2(Clone)")
        {
            sideGOY = gameObject.GetComponent<BoxCollider2D>().size.y;
            type2 = true;
            startVelType2();
            xpType = 3;
            
        }
        else if (gameObject.name == "Meteorite3(Clone)")
        {
            sideGOY = gameObject.GetComponent<CapsuleCollider2D>().size.y;
            type2 = true;
            startVelType2();
            xpType = 3;
           
        }
        
    }


    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.name == "TestNave")
        {
            gameManager.GetComponent<hpShootNave>().lessHp();
            Destroy(gameObject);
        }
       // Destroy(gameObject, timeDestruction);
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

    //  add animacion de destruccion
    void die()
    {
        if (hp <= 0 && !dieOneTime)
        {
            explosion.Play();
            if(gameObject.name == "Meteorite2(Clone)" || gameObject.name == "Meteorite2")
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
            else
            {
                gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            }

            gameObject.GetComponent<Animator>().SetInteger("life", hp);
        
            rb.linearVelocity = Vector2.zero;
       
            GenerateXPOrPU();
            Destroy(gameObject, 0.6f);
            dieOneTime = true; 
        }
    }
  
    void GenerateXPOrPU()
    {
       if ( minutes < 2)
        {
            Xp();
        }
        else
        {
            float Probability = Random.Range(0f, 1f);
            if (Probability<0.8)
            {
                Xp();
            }
            else
            {
                Pu();
            }
        }

    }

    void Pu()
    {
        float randomType = Random.Range(0f, 1f);
        print(randomType); 
        if (randomType < 0.55)
        {
            Instantiate(PUs[0], new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
        }
        else
        {
            Instantiate(PUs[1], new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
        }
       // generar gameobjects de power ups
    }


    //instantiate xp
    void Xp()
    {
        int provisionalType = xpType - 1;
        if ((seconds < 30) && (minutes == 0))
        {
            provisionalType = 0;
        }

        GameObject provisionalXP = XPs[provisionalType];
        Instantiate(provisionalXP, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
    }

    public void damage (int dmg)
    {
        hp -= dmg; 
    }

    void meteoriteType1(float plus)
    {

        if ((seconds >= 30) && (minutes <= 00))
        {
            rb.linearVelocity = new Vector2(-3f -plus, 0); //Mathf.Sin(gameObject.transform.position.x)
        }
        else if (minutes >= 01 && minutes < 3)
        {
            rb.linearVelocity = new Vector2(-4f - plus, 0);
        }
        else if ((minutes >= 3) && (minutes < 05))
        {
            rb.linearVelocity = new Vector2(-5f - plus, 0);
        }
        else if (minutes >= 05)
        {
            rb.linearVelocity = new Vector2(-6f - plus, 0);
        }
    }
    
    void meteoriteType2()
    {
        //movimiento del segundo tipo de meteorito
        if (type2)
        {
            changeVelY();
            rb.linearVelocity = new Vector2(velocityX, velocityY);
        }
       



    }

    void startVelType2()
    {
        if ((seconds < 30) && (minutes <= 00))
        {
            velocityX = -2f;
            velocityY = 0f; 
        }
        else if ((seconds >= 30) && (minutes <= 00))
        {
            velocityY = Random.Range(1f, 3f);
            velocityX = Random.Range(-2f, -4f);
        }
        else if (minutes >= 01 && minutes < 3)
        {
            velocityY = Random.Range(2f, 4f);
            velocityX = Random.Range(-3f, -5f);
        }
        else if ((minutes >= 3) && (minutes < 05))
        {
            velocityY = Random.Range(3f, 5f);
            velocityX = Random.Range(-4f, -6f);
        }
        else if (minutes >= 05)
        {
            velocityY = Random.Range(4f, 8f);
            velocityX = Random.Range(-5f, -8f);
        }

        if (gameObject.transform.position.y > 0f)
        {
            velocityY *= -1;
        }

    }
    void changeVelY()
    { 
        if (velocityY != 0f)
        {
            //cambio si llega a los bordes
            if ((gameObject.transform.position.y + (sideGOY/4 ) >= MaxY && velocityY>0f)||(gameObject.transform.position.y - (sideGOY/4 ) <= -MaxY && velocityY < 0f))
            {
                velocityY *= -1;
            } 
        }
    }



    /* void meteorite3Move()
     {

         if ((seconds >= 30) && (minutes <= 00))
         {
             rb.velocity = new Vector2(-3f, Mathf.Cos(gameObject.transform.position.x)); 
         }
         else if (minutes >= 01 && minutes < 3)
         {
             rb.velocity = new Vector2(-4f, Mathf.Cos(gameObject.transform.position.x)*2f);
         }
         else if ((minutes >= 3) && (minutes < 05))
         {
             rb.velocity = new Vector2(-5f, Mathf.Cos(gameObject.transform.position.x)*3f);
         }
         else if (minutes >= 05)
         {
             rb.velocity = new Vector2(-6f, Mathf.Cos(gameObject.transform.position.x)*5f);
         }
     }

     void meteorite4Move()
     {

         if ((seconds >= 30) && (minutes <= 00))
         {
             rb.velocity = new Vector2(-5f, 0f); 
         }
         else if (minutes >= 01 && minutes < 3)
         {
             rb.velocity = new Vector2(-6f, 0f);
         }
         else if ((minutes >= 3) && (minutes < 05))
         {
             rb.velocity = new Vector2(-7f, 0f);
         }
         else if (minutes >= 05)
         {
             rb.velocity = new Vector2(-8f, 0f);
         }
     }
    */

    //sumar puntos cuando se destroza un meteorito
}
