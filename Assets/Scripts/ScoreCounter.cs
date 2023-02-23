using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    public static ScoreCounter Instance;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI panelScoreText;
    public TextMeshProUGUI diamondText;

    public int score;
    public int diamond;
    
    public int newScore;

    private int Score
    {
        get => score;
        set
        {
            score = value;
            scoreText.text = score.ToString();
            panelScoreText.text = score.ToString();
        }
    }

    private int Diamond
    {
        get => diamond;
        set
        {
            diamond = value;
            diamondText.text = diamond.ToString();
        }
    }

    private void Awake() => Instance = this;
    private void Start() => Score = 0;

    public void AddScore(int value) => Score += value;
    
    public void RemoveScore(int value) => Score -= value; //TODO 

    public void AddDiamond(int value)
    {
        Diamond += value;
    }
}
