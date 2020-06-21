using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoSceneChange : MonoBehaviour
{
    public float Time_For_Scene_Change;

    void Start()
    {
        StartCoroutine(SceneChange());
    }

    IEnumerator SceneChange()
    {
        yield return new WaitForSeconds(Time_For_Scene_Change);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
