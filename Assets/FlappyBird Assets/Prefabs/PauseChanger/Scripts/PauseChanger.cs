using UnityEngine;

public class PauseChanger : MonoBehaviour
{
    public static PauseChanger Instance;
    private bool _isGamePaused = false; //Проверка на паузу в игре

    private void Start()
    {
        Instance = this;
    }

    private void Update()
    {
        CheckingPause();
    }

    private void CheckingPause()
    {
        if(!GameState.Instance._isGameLost)
        {
            if(Input.GetKeyDown(KeyCode.Escape)) //Не дает нажиматься кнопке ESC во время проигрыша
            {   
                _isGamePaused = !_isGamePaused; //Переключатель паузы
                PauseChanger.Instance.PauseChange(_isGamePaused);
            }
        }
    }

    public void PauseChange(bool _isGamePaused)
    {
        if(_isGamePaused) //Запускает паузу
        {
            PauseGame(); 
        }
        else ContinueGame();
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
}
