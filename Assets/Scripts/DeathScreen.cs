using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public GameObject object_death_screen;
    public GameObject object_gameUI;
    public TextMeshProUGUI text_score;

    public TMP_InputField inputField_name;

    public void Activate()
    {
        object_death_screen.SetActive(true);
        object_gameUI.SetActive(false);

        int score = ScoreSystem.score;

        text_score.text = "SCORE:"+score.ToString();
    }
    public void retry()
    {
        if(inputField_name.text == "") inputField_name.text = "mysteriousStranger";
        AddScore(inputField_name.text,ScoreSystem.score);

        ScoreSystem.score = 0;
        SceneManager.LoadScene(1);
        
    }
    public void GoToMenu()
    {
        ScoreSystem.score = 0;
        SceneManager.LoadScene(0);
    }

    [DllImport("__Internal")]
    private static extern void AddScore(string playerName,int playerScore);
}
