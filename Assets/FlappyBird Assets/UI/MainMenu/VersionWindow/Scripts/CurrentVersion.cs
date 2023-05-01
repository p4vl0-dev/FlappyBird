using UnityEngine;
using UnityEngine.UI;

public class CurrentVersion : MonoBehaviour
{
    private Text _currentVersionText;

    private void Start()
    {
        _currentVersionText = GetComponent<Text>();
        _currentVersionText.text = "Version: " + Application.version;
    }
}
