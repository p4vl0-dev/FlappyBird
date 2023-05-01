using UnityEngine;
using UnityEngine.UI;

public class LocalScoreCounter : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] private Text _localScoreText;
    [SerializeField] private Text _finalScoreText;
    
    public static int localScore = 0;
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
        _localScoreText.text = localScore.ToString();
    }

    public void SetFinalScoreText()
    {
        _finalScoreText.text = localScore.ToString();
    }
}
