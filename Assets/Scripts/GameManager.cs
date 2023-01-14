using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager: MonoBehaviour
{
    public GameObject LoseWindow;
    public GameObject ScoreWindow;
    public static GameManager instanceManager;

    private void Start(){
        instanceManager = this;
    }

    public void RestartScene(){
        ScoreManager.score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void Lose(){
        Time.timeScale = 0;
        Spawner.SetDefaults();
        PipeMove.SetDefaults();
        LoseWindow.SetActive(true);
        ScoreWindow.SetActive(false);
    }

    public void LoadScene(int sceneNumber){
        SceneManager.LoadScene(sceneNumber);
        ScoreManager.score = 0;
        Time.timeScale = 1;
    }

    public void Quit(){
        Application.Quit();
    }

}
