using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public KeyCode pauseKey = KeyCode.Escape;
    public GameObject pauseMenu;
    bool isPaused = false;
    void Update()
    {
        if(Input.GetKeyDown(pauseKey))
        {
            if(isPaused)
            {
                UnPauseGame();
            }
            else PauseGame();
        }
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);

        isPaused = true;
    }
    public void UnPauseGame()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);

        isPaused = false;
    }

}
