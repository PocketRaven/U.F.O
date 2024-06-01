using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public int winningScore = 250; 
    public GameObject winningPanel; 

    private int score = 0;
    private bool gameEnded = false; 

    public void AddScore(int points)
    {
        if (!gameEnded)
        {
            score += points;
            UpdateScoreText();

            // onko pelaaja saavuttanut pisteet
            if (score >= winningScore)
            {
                ShowWinningPanel();
                EndGame();
            }
        }
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    private void ShowWinningPanel()
    {
        if (winningPanel != null)
        {
            winningPanel.SetActive(true);
        }
    }

    private void EndGame()
    {
        Time.timeScale = 0;
    }
}