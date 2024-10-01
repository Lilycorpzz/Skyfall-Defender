using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CreditSceneManager : MonoBehaviour
{
    public TextMeshProUGUI finalScoreText; // Text component in the Credit scene to show the score

    void Start()
    {
        // Display the final score from the ScoreManager
        if (finalScoreText != null)
        {
            finalScoreText.text = "Final Score: " + ScoreManager.Instance.score.ToString();
        }
    }
}
