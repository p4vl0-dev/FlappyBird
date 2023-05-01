using UnityEngine;
using UnityEngine.UI;

public class BestScoreChanger : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] private Text _bestScoreText;

    public static BestScoreChanger Instance;
    
    private int _currentBestScore;

    private void Start()
    {
        Instance = this;

        if(PlayerPrefs.HasKey("BestScore"))
        {
            GetBestScore();
        } 
        else _currentBestScore = 0;
    }

    private void GetBestScore()
    {
        _currentBestScore = PlayerPrefs.GetInt("BestScore", _currentBestScore);
    }

    private void SetBestScore(int _currentBestScore)
    {
        PlayerPrefs.SetInt("BestScore", _currentBestScore);
    }

    public void SetBestScoreText()
    {
        _bestScoreText.text = _currentBestScore.ToString();
    }

    public void UpdateBestScore()
    {
        if(LocalScoreCounter.localScore > _currentBestScore)
        {
            _currentBestScore = LocalScoreCounter.localScore;
            SetBestScore(_currentBestScore);
        }
    }
}
