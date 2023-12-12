using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private int playerScore;

    private void Start()
    {
        GameEvents.Instantiate.ADDScore += UpdateScore;
        ResetScore();
    }

    private void ResetScore()
    {
        playerScore = 0;
    }
    
    private void UpdateScore(int obj)
    {
        scoreText.text = "Score: " + AddScore(obj);
    }

    private int AddScore(int value)
    {
        playerScore += value;
        return playerScore;
    }
}
