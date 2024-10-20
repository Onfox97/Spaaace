using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public GameObject object_death_screen;
    public GameObject object_gameUI;
    public TextMeshProUGUI text_score;
    public TextMeshProUGUI text_high_score;

    public void Activate()
    {
        object_death_screen.SetActive(true);
        object_gameUI.SetActive(false);

        int score = ScoreSystem.score;
        int high_score = PlayerPrefs.GetInt("HighScore");

        if(high_score < score)
        {
            high_score = score;
            PlayerPrefs.SetInt("HighScore",score);
        }

        text_score.text = "SCORE:"+score.ToString();

        text_high_score.text = "HIGH SCORE:"+high_score.ToString();
    }
    public void retry()
    {
        ScoreSystem.score = 0;
        SceneManager.LoadScene(1);
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
