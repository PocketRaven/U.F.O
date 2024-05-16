using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public int winningScore = 250; // Adjust as needed
    public GameObject winningPanel; // Reference to the winning panel

    private int score = 0;
    private bool gameEnded = false; // Flag to track if the game has ended

    public void AddScore(int points)
    {
        if (!gameEnded)
        {
            score += points;
            UpdateScoreText();

            // Check if the player has reached the winning score
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