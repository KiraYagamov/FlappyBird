using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public static UI Main;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject buttons;
    [SerializeField] private Text scoreText;

    private void Start()
    {
        Main = this;
    }

    public void ShowMenu()
    {
        Time.timeScale = 0;
        panel.SetActive(true);
        buttons.SetActive(true);
    }

    public void CloseMenu()
    {
        if (PlayerController.IsGameOver)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            PlayerController.IsGameOver = false;
        }
        Time.timeScale = 1;
        panel.SetActive(false);
        buttons.SetActive(false);
    }

    public void SetScore(int score, int maxScore)
    {
        scoreText.text = $"{score}/{maxScore}";
    }
}
