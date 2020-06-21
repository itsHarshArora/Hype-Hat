using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public static int score;
    public static int pointIncreasePerSecond = 1;
    public Text scoreText;

    public Text scoreStatsText;
    public GameObject scoreStats;

    void Start()
    {
        score = 0;
        scoreText = GetComponent<Text>();
        scoreStatsText = scoreStats.GetComponent<Text>();
    }
    private void Update()
    {
        score += pointIncreasePerSecond;
        scoreText.text = score.ToString();
        scoreStatsText.text = scoreText.text;
    }
}
