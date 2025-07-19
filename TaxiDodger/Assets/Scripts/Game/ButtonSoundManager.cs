using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ButtonSoundManager : MonoBehaviour
{
    //public AudioClip hoverSound;  // Sound for hovering
    public AudioClip clickSound;  // Sound for clicking
    public float volume = 1f;     // Sound volume

    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        // Find all buttons in the scene
        AddSoundsToAllButtons();
    }

    void AddSoundsToAllButtons()
    {
        Button[] buttons = FindObjectsOfType<Button>();

        foreach (Button btn in buttons)
        {
            // Add hover sound
            EventTrigger trigger = btn.GetComponent<EventTrigger>();
            if (trigger == null)
                trigger = btn.gameObject.AddComponent<EventTrigger>();

            EventTrigger.Entry hoverEntry = new EventTrigger.Entry();
            hoverEntry.eventID = EventTriggerType.PointerEnter;
            //hoverEntry.callback.AddListener((data) => { PlayHoverSound(); });
            trigger.triggers.Add(hoverEntry);

            // Add click sound
            btn.onClick.AddListener(PlayClickSound);
        }
    }

    //void PlayHoverSound()
    //{
    //    if (hoverSound != null)
    //        audioSource.PlayOneShot(hoverSound, volume);
    //}

    void PlayClickSound()
    {
        if (clickSound != null)
            audioSource.PlayOneShot(clickSound, volume);
    }
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        AddSoundsToAllButtons();
    }
}
