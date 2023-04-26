using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    [HideInInspector] public bool _isGameLost = false;
    public static GameState Instance;

    private void Start()
    {
        Instance = this;
    }

    public void Lose()
    {   
        _isGameLost = true; //Инициализирует проигрыш и не дает паузе открываться

        BestScoreChanger.Instance.UpdateBestScore();
        BestScoreChanger.Instance.SetBestScoreText();

        LocalScoreCounter.Instance.SetFinalScoreText();

        Time.timeScale = 0;

        PipeSpawner.SetDefaults();
        PipeMove.SetDefaults();

        WindowController.Instance.loseWindow.SetActive(true);
        WindowController.Instance.scoreWindow.SetActive(false);
        WindowController.Instance.pauseMenu.SetActive(false);
    }

    public void PauseGame() //Для паузы в игре
    {
        Time.timeScale = 0;
        WindowController.Instance.pauseMenu.SetActive(true);
    }

    public void ContinueGame() //Для продолжения игры
    {
        WindowController.Instance.pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void PauseChange(bool _isGamePaused)
    {
        if(_isGamePaused) //Запускает паузу
        {
            PauseGame(); 
        }

        if(!_isGamePaused) //Отключает меню паузы
        {
            ContinueGame();
        }
    }

    public void LoadScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
        LocalScoreCounter.localScore = 0;
        Time.timeScale = 1;
    }

    public void RestartCurrentScene()
    {
        LocalScoreCounter.localScore = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}
