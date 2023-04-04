using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{   
    public static ScoreManager Instance;
    [SerializeField] private Text _scoreText; // для отражения приватных перемен в инспекторе
    public Text _currentHighScoreText;
    public static int score = 0;
    public static int ScoreLimit = 10;
    private int _currentHighScore;
    
    public void Start()
    {
        Instance = this;

        if(PlayerPrefs.HasKey("HighestScore"))
        {
            _currentHighScore = PlayerPrefs.GetInt("HighestScore", _currentHighScore);
        } 
        else _currentHighScore = 0;
    }

    private void Update()
    {
        SetScore();
    }

    public void SetScore()
    {
        if(score < 0)
        {
            GameManager.instanceManager.Lose();
            _scoreText.text = "You fool, why u cheat?";
        } 
        else 
        {
            _scoreText.text = "Score: " + score.ToString();
        }
    }

    public void SetHighScore()
    {
        if(score > _currentHighScore)
        {
            _currentHighScore = score;
            PlayerPrefs.SetInt("HighestScore", _currentHighScore);
        }
    }

    public void SetHighScoreText()
    {
        _currentHighScoreText.text = "Best: " + _currentHighScore;
    }
}
