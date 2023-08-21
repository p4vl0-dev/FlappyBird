using UnityEngine;

public class GameState : MonoBehaviour
{
    [HideInInspector] public bool _isGameLost = false;

    public static GameState Instance;

    private void Start()
    {
        Instance = this;
    }
    
    public void PlayerDies()
    {
        _isGameLost = true; //Инициализирует проигрыш и не дает паузе открываться

        HitEffect.PlayHitEffect();
        DieRotation.PlayDieRotate();
    }

    public void Lose()
    {   
        BestScoreChanger.Instance.UpdateBestScore();
        BestScoreChanger.Instance.SetBestScoreText();

        LocalScoreCounter.Instance.SetFinalScoreText();
        
        WindowController.Instance.loseWindow.SetActive(true);
        WindowController.Instance.scoreWindow.SetActive(false);
        WindowController.Instance.pauseMenu.SetActive(false);

        Time.timeScale = 0;
    }
}
