using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Return()
    {
        Time.timeScale = 1;
    }
    public void RMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }
    public GameObject a;
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            a.SetActive(true);
            Pause();
        }
    }
}
