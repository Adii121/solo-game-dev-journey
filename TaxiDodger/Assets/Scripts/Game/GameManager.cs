using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public TextMeshProUGUI scoreText;
    public GameObject gameOverPanel;

    // Speed system
    public float baseSpeed = 2f;           // Starting speed
    public float maxSpeed = 10f;           // Cap for taxi speed
    public float minSpeed = 2f;            // Taxi never goes slower than this
    public float permanentModifier = 0f;   // Power-ups that affect speed forever
    public float temporaryModifier = 0f;   // For timed effects (future)
    public float rickshawSpeed;            // Final calculated speed

    private int score = 0;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        // Calculate speed
        float calculatedSpeed = baseSpeed + (score / 5f);
        rickshawSpeed = Mathf.Clamp(calculatedSpeed + permanentModifier + temporaryModifier, minSpeed, maxSpeed);
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score;
    }

    public void ApplyPermanentSlowdown(float amount)
    {
        permanentModifier -= amount;
        Debug.Log($"Permanent slowdown applied: -{amount}. Total modifier: {permanentModifier}");
    }

    public void GameOver()
    {
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }

        Time.timeScale = 0; 
        gameOverPanel.SetActive(true);
        GameObject bgMusic = GameObject.FindGameObjectWithTag("BackgroundMusic");
        if (bgMusic != null)
        {
            AudioSource audio = bgMusic.GetComponent<AudioSource>();
            if (audio.isPlaying)
            {
                audio.Stop();
            }
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GameScene");
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
