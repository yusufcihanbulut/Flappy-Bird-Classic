using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text ScoreText;
    public int score;

    public void UpdateScore()
    {
        score++;
        ScoreText.text = score.ToString();
    }
    void Start()
    {
        score = 0;
        ScoreText.text = score.ToString();
    }
    public void RestartGame ()
    {
        SceneManager.LoadScene(0);
    }
}
