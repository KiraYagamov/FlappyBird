using UnityEngine;

public class Scoreboard : MonoBehaviour
{
    public static Scoreboard Main;
    private int _score = 0;
    private int _maxScore = 0;

    private void Start()
    {
        Main = this;
        _maxScore = PlayerPrefs.GetInt("MaxScore");
    }

    private void Update()
    {
        UI.Main.SetScore(_score, _maxScore);
    }

    public void AddPoint()
    {
        _score++;
    }

    public void SaveScore()
    {
        if (_maxScore < _score)
            PlayerPrefs.SetInt("MaxScore", _score);
    }
}
