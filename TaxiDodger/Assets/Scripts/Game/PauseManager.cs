using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenuCanvas;
    public GameObject pausePanel;
    public GameObject settingsPanel;

    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void PauseGame()
    {
        pauseMenuCanvas.SetActive(true);
        Time.timeScale = 0f; // Freeze the game
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f; // Resume the game
        isPaused = false;
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f; // Reset time
        SceneManager.LoadScene("MainMenu"); // Change this to your menu scene name
    }
    public void OpenSettings()
    {
        pausePanel.SetActive(false);   // Disable pause buttons
        settingsPanel.SetActive(true); // Show settings panel
    }
    public void CloseSettings()
    {
        settingsPanel.SetActive(false); // Hide settings panel
        pausePanel.SetActive(true);     // Bring back pause buttons
    }
}
