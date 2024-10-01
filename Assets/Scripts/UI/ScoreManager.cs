using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance; // Singleton instance to access score globally
    public int score = 0; // The player's score
    public TextMeshProUGUI scoreText; // UI text to display the score in the Game scene

    void Awake()
    {
        // Singleton pattern: Only one instance of ScoreManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep ScoreManager across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Method to add points to the score
    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    // Method to update the score display in the Game scene
    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }

    // Method to reset the score (if you want to reset on restart)
    public void ResetScore()
    {
        score = 0;
        UpdateScoreText();
    }
}
