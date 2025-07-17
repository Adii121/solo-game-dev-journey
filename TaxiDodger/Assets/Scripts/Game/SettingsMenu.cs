using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public GameObject settingsPanel;
    public Slider masterVolumeSlider;

    void Start()
    {
        // Load saved master volume or default to 1
        float savedVolume = PlayerPrefs.GetFloat("MasterVolume", 1f);

        // Set the slider value
        masterVolumeSlider.value = savedVolume;

        // Apply volume at startup
        AudioListener.volume = savedVolume;

        // Hook up the slider
        masterVolumeSlider.onValueChanged.AddListener(SetMasterVolume);
    }

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }

    public void SetMasterVolume(float volume)
    {
        // Set global Unity audio volume
        AudioListener.volume = volume;

        // Save volume for future sessions
        PlayerPrefs.SetFloat("MasterVolume", volume);
    }
}
