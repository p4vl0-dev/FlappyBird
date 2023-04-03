using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{   
    public static ScoreManager Instance;
    [SerializeField] private Text _scoreText; // для отражения приватных перемен в инспекторе
    public static int score = 0;
    public static int ScoreLimit = 10;
    
    public void Start()
    {
        Instance = this;
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

}
