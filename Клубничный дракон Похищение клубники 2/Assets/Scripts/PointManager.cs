using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class PointManager : MonoBehaviour
{
    public TMP_Text finalScoreText;
    public TMP_Text scoreText;

    public int score;
    
    void Start()
    {
        scoreText.text = "" + score;
    }

    public void UpdateScore(int points)
    {
        score += points;
        scoreText.text = "" + score;
    }
}
