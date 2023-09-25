using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cambiarEscena : MonoBehaviour
{
   public void Nivel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
    public void Quitar()
    {
        Application.Quit();
    }
}
