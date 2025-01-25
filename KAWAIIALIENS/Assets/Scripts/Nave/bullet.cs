using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rb;
    int damage;
    [SerializeField]
    float fxVolume;

    // Start is called before the first frame update
    void Start()
    {
        rb.linearVelocity = transform.right * speed;
        fxVolume = GameObject.FindGameObjectWithTag("GameController").GetComponent<volumenController>().getFxValue();
        AudioSource fx = gameObject.GetComponent<AudioSource>();
        fx.volume = fxVolume;
        damage = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().get_damage();

     
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collision)
    {
       
      
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<meteoritesContrroller>().damage(damage);
            Destroy(gameObject);
        }
        else if (collision.CompareTag("experience"))
        {
            collision.GetComponent<ExperienceScript>().lessHp(damage);
            Destroy(gameObject);
        }
        else if (collision.CompareTag("PowerUpTag"))
        {
            collision.GetComponent<PUScript>().lessHp(damage);
            Destroy(gameObject);
        }

        Destroy(gameObject,2f);
    }

   // aplicar damage a enemigo
}
