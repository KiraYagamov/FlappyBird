using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public static UI Main;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject buttons;
    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject gameOver;

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

    public void GameOver()
    {
        gameOver.SetActive(true);
    }

    public void CloseMenu()
    {
        if (PlayerController.IsGameOver)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            PlayerController.IsGameOver = false;
            PlayerController.GameSpeed = 1;
        }
        Time.timeScale = PlayerController.GameSpeed;
        panel.SetActive(false);
        buttons.SetActive(false);
        gameOver.SetActive(false);
    }

    public void SetScore(int score, int maxScore)
    {
        scoreText.text = $"{score}/{maxScore}";
    }

    public void Menu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
}
