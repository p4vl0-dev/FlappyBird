using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager: MonoBehaviour
{
    public GameObject ScoreWindow;
    public GameObject LoseWindow;
    public GameObject PauseMenu;
    //HideInInspector - не показывает в инспекторе данное поле
    [HideInInspector] public bool _isGameLosed = false; //Поле, которое показывает - проиграна игра или нет. Помогает работать PauseMenu
    
    public static GameManager instanceManager; //Для использования не статичных методов в других скриптах(классах)

    private void Start()
    {
        instanceManager = this;
    }

    public void RestartScene()
    {
        ScoreManager.score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void LoadScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
        ScoreManager.score = 0;
        Time.timeScale = 1;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Lose()
    {   
        _isGameLosed = true; //Инициализирует проигрыш и не дает паузе открываться

        ScoreManager.Instance.SetHighScore();
        ScoreManager.Instance.SetHighScoreText();

        Time.timeScale = 0;
        PipeSpawner.SetDefaults();
        PipeMove.SetDefaults();

        LoseWindow.SetActive(true);
        ScoreWindow.SetActive(false);
        PauseMenu.SetActive(false);
    }

    public void Pause() //Для паузы в игре
    {
        Time.timeScale = 0;
        PauseMenu.SetActive(true);
    }
    
    public void Continue() //Для продолжения игры
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void MenuChanger(bool _isGamePaused)
    {
        if(_isGamePaused == true) //Запускает паузу
        {
            Pause(); 
        }

        if(_isGamePaused == false) //Отключает меню паузы
        {
            Continue();
        }
    }
}
