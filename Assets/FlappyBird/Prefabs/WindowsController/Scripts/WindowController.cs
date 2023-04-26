using UnityEngine;

public class WindowController: MonoBehaviour
{
    public GameObject scoreWindow;
    public GameObject loseWindow;
    public GameObject pauseMenu;

    public static WindowController Instance;

    private void Start()
    {
        Instance = this;
    }
}
