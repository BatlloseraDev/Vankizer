using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyerScript : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject gameManager;
    float sizeY;
    float sizeX;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController");
        sizeX = gameManager.GetComponent<GameManager>().GetSizeX();
        sizeY = gameManager.GetComponent<GameManager>().GetSizeY();

       
        gameObject.transform.position =new Vector3 (-sizeX-10f,0,0);
        gameObject.transform.localScale = new Vector3(0.5f, sizeY * 2f, 0f);

    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(sizeY);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        Destroy(collision.gameObject);
   
    }
}
