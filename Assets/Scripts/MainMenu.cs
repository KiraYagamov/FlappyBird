using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        Application.targetFrameRate = 120;
    }

    public void Play()
    {
        SceneManager.LoadScene("Game");
    }
}
