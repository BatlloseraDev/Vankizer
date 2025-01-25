using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starsController : MonoBehaviour
{
    // Start is called before the first frame update
    private float timeDestruction = 10f;
    private Rigidbody2D rb;
  

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        randomStats();
        //Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void randomStats()
    {
        float type1 = Random.Range(0f, 10f);
        if (type1 <= 2f)
        {
            rb.linearVelocity = new Vector2(-1f, 0);
        }
        else if(type1>2f && type1 <= 4f)
        {
            rb.linearVelocity = new Vector2(-2f, 0);
        }
        else if (type1 > 4f && type1 <= 7f)
        {
            rb.linearVelocity = new Vector2(-3f, 0);
        }
        else if (type1 > 7f && type1 <= 9f)
        {
            rb.linearVelocity = new Vector2(-5f, 0);
        }
        else
        {
            rb.linearVelocity = new Vector2(-8f, 0);
        }

        Color star = GetComponent<SpriteRenderer>().color;
        star.a = Random.Range(0, 1f);
        gameObject.GetComponent<SpriteRenderer>().color = star;
  
    }
}
