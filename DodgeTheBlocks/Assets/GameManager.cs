using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TextMeshProUGUI scoreText;
    public GameObject gameOverPanel;
    public float blockFallSpeed = 2f;
    public TextMeshProUGUI moveText;
    public Movement player;

    private int score = 0;

    void Awake()
    {
        instance = this;
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score;

        // Update difficulty every 5 points
        blockFallSpeed = 2f + (score / 5f); // or tweak the divisor as needed
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
        Debug.Log("Game Over Triggered");
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    void Update()
    {
        moveText.text = "Stamina: " + Mathf.RoundToInt(player.currentStamina) + "/" + player.maxStamina;
    }
}
