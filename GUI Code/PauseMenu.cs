using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pMenu;

    public void GameRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale =1;

    }
    public void GameResume()
    {
        pMenu.SetActive(false);
        Time.timeScale = 1;

    }
    public void GamePause()
    {
        pMenu.SetActive(true);
        Time.timeScale = 0;

    }
    public void MainMenuScreen()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale =1;
        
    }
}

