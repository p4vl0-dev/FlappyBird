using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadCurrentScene : MonoBehaviour
{
    public void LoadScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);

        LocalScoreCounter.localScore = 0;

        Time.timeScale = 1;
    }
}
