using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class LoadScene : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject pantallaDeCarga;
    public Slider slider; 


  public void CargarNivel(int NumeroDeEscena)
  {
        StartCoroutine(CargarAsyn(NumeroDeEscena));
  } 


    IEnumerator CargarAsyn(int NumeroDeEscena)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(NumeroDeEscena);
        pantallaDeCarga.SetActive(true); 

        while (!operation.isDone)
        {
            float Progreso = Mathf.Clamp01(operation.progress / .9f);
           
            slider.value = Progreso; 

            yield return null; 

        }



    }

    public void CerrarJuego()
    {
        Application.Quit();
    }

}
