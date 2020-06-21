using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject restartPanel;

    void Start()
    {
        startPanel.SetActive(true);
        ScoreCounter.pointIncreasePerSecond = 0;
        Time.timeScale = 0f;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && startPanel.activeSelf == true)
        {
            startPanel.SetActive(false);
            ScoreCounter.pointIncreasePerSecond = 1;
            Time.timeScale = 1f;
        }
        if (restartPanel.activeSelf == true)
        {
            ScoreCounter.pointIncreasePerSecond = 0;
        }
        if (Input.GetKeyDown(KeyCode.Space) && restartPanel.activeSelf == true)
        {
            SceneManager.LoadScene("Game");
        }
    }
}
