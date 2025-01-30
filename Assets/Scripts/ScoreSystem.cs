using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public static int score = 0;
    public TextMeshProUGUI text_dispay_score;
    void Update()
    {
        text_dispay_score.text = "SCORE:"+score.ToString();
    }
    public static void addScore(int additional_ammout)
    {
        score += additional_ammout;
    }
}
