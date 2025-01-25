using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class pauseEvent : MonoBehaviour
{
    // Start is called before the first frame update



    void Start()
    {
        pausegame(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     public void pausegame()
    {
        Time.timeScale = 0f;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
    public void RechargeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
