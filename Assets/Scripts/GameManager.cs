using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager: MonoBehaviour
{
    public GameObject ScoreWindow;
    public GameObject LoseWindow;
    public static GameManager instanceManager;

    private void Start(){
        instanceManager = this;
    }

    public void RestartScene(){
        ScoreManager.score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void LoadScene(int sceneNumber){
        SceneManager.LoadScene(sceneNumber);
        ScoreManager.score = 0;
        Time.timeScale = 1;
    }

    public void Exit(){
        Application.Quit();
    }

    public void Lose(){
        Time.timeScale = 0;
        Spawner.SetDefaults();
        PipeMove.SetDefaults();
        LoseWindow.SetActive(true);
        ScoreWindow.SetActive(false);
    }
}
