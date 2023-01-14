using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{   
    public static ScoreManager Instance;
    [SerializeField] private Text scoreText; // для отражения приватных перемен в инспекторе
    public static int score = 0;

    public void Start(){
        Instance = this;
    }

    private void Update(){
        SetScore();
    }

    public void SetScore(){
        scoreText.text = "Score: " + score.ToString();
    }

}
