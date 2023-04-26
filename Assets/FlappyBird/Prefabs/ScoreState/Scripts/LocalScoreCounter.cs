using UnityEngine;
using UnityEngine.UI;

public class LocalScoreCounter : MonoBehaviour
{
    [SerializeField] private Text _localScoreText;
    [SerializeField] private Text _finalScoreText;
    public static int localScore = 0;
    public static int localScoreLimit = 10;
    public static LocalScoreCounter Instance;

    private void Start()
    {
        Instance = this;
    }

    private void Update()
    {
        SetLocalScoreText();
    }
    
    public void AddScore(int addingScore)
    {
        localScore += addingScore;
    }

    private void SetLocalScoreText()
    {
        _localScoreText.text = "Score: " + localScore;
    }

    public void SetFinalScoreText()
    {
        _finalScoreText.text = "Score: " + localScore;
    }
}
