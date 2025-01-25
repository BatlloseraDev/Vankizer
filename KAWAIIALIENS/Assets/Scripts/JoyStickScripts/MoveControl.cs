using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControl : MonoBehaviour
{

    [SerializeField]
    private GameObject stick, panel;
    private Rigidbody2D rb;
    private float movespeed;
    private Touch oneTouch;
    private Vector2 touchPosition;
    private Vector2 moveDirection;

    private Vector2 testPosition;

    //calculo de pantalla
    float MaxX;
    float MaxY;
    float sideGOX;
    float sideGOY;




    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        stick.SetActive(false);
        panel.SetActive(false);
        movespeed = 3f;

        var unitsInY = Camera.main.orthographicSize *2f;
        var unitsInX = unitsInY * ((float)Screen.width / (float)Screen.height);

        MaxX = unitsInX / 2;
        MaxY = unitsInY / 2;
        print("units in Y: " + MaxY +" units in X: "+ MaxX);

       sideGOX = gameObject.transform.localScale.x;
       sideGOY = gameObject.transform.localScale.y;



    }

    // Update is called once per frame
    void Update()
    {

       
        

        //test mode
        testMode();
        ControllerPad();
        ControlSide();

        //fin del control por teclado

        //print("La posicion actual es: en x "+ gameObject.transform.position.x + " en y " + gameObject.transform.position.y);

        //print("Screen width: " + Screen.width + " Screen Height: "+ Screen.height);

    }//fin update

    private void ControlSide()
    {
        if (gameObject.transform.position.x +(sideGOX/2) >= MaxX && rb.linearVelocity.x >0f)
        {
            rb.linearVelocity = new Vector2(0f, rb.linearVelocity.y);
        }
        else if(gameObject.transform.position.x - (sideGOX / 2) <= -MaxX && rb.linearVelocity.x < 0f)
        {
            rb.linearVelocity = new Vector2(0f, rb.linearVelocity.y);
        }
        
        if(gameObject.transform.position.y + (sideGOY / 2) >= MaxY && rb.linearVelocity.y > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
        }
        else if(gameObject.transform.position.y - (sideGOY / 2) <= -MaxY && rb.linearVelocity.y < 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
        }

        /* if(gameObject.transform.position.x>=MaxX || gameObject.transform.position.x<= -MaxX)
         {
             rb.velocity = new Vector2(0f, rb.velocity.y);
         }
         if(gameObject.transform.position.y >= MaxY || gameObject.transform.position.y<= -MaxY)
         {
             rb.velocity = new Vector2(rb.velocity.x, 0f); 
         }*/
    }


    private void ControllerPad()
    {
        if (Input.touchCount == 1 )
        {
            oneTouch = Input.GetTouch(0);

            touchPosition = Camera.main.ScreenToWorldPoint(oneTouch.position);


            if (touchPosition.x < 0)
            {
                switch (oneTouch.phase)
                {
                    case TouchPhase.Began:

                        panel.SetActive(true);
                        stick.SetActive(true);

                        panel.transform.position = touchPosition;
                        stick.transform.position = touchPosition;
                        break;

                    case TouchPhase.Stationary:

                        MoveNave();

                        break;

                    case TouchPhase.Moved:
                        MoveNave();

                        break;

                    case TouchPhase.Ended:

                        panel.SetActive(false);
                        stick.SetActive(false);

                        rb.linearVelocity = Vector2.zero;

                        break;
                }// fin del switch
            }// fin del if mitad pantalla
            else if (touchPosition.x >= 0)
            {
                panel.SetActive(false);
                stick.SetActive(false);
                rb.linearVelocity = Vector2.zero;
            }
        } //fin del if 
        else if (Input.touchCount > 1)
        {
            Touch touch;
            
            for( int i = 0; i< Input.touchCount; i++)
            {

                touch = Input.GetTouch(i);

                //if(touch)
            }
        }


    }
    private void MoveNave()
    {
        stick.transform.position = touchPosition;
        stick.transform.position = new Vector2(
            Mathf.Clamp(stick.transform.position.x,
            panel.transform.position.x -0.5f,
            panel.transform.position.x +0.5f),
            Mathf.Clamp(stick.transform.position.y,
            panel.transform.position.y - 0.5f,
            panel.transform.position.y + 0.5f)
            );

        moveDirection = (stick.transform.position - panel.transform.position).normalized;
        rb.linearVelocity = moveDirection * movespeed;

    }

    private void testMode()
    {


        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.linearVelocity = new Vector2(0f, 0.5f) * movespeed;

        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            rb.linearVelocity = new Vector2(0.5f, 0f) * movespeed;

        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            rb.linearVelocity = new Vector2(0f, rb.linearVelocity.y);
        }


        if (Input.GetKeyDown(KeyCode.A))
        {
            rb.linearVelocity = new Vector2(-0.5f, 0f) * movespeed;

        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            rb.linearVelocity = new Vector2(0f, rb.linearVelocity.y);
        }


        if (Input.GetKeyDown(KeyCode.S))
        {
            rb.linearVelocity = new Vector2(0f, -0.5f) * movespeed;

        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
        }




        if (Input.GetMouseButtonDown(0))
        {
            testPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            print("la posicion click es en X: " + testPosition.x +" en y: " + testPosition.y);
        }


    }
}
