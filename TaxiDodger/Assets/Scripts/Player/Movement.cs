using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float laneDistance = 2f;
    public PlayerStamina playerStamina;
    public GameObject dodgeEffectPrefab;
    public AudioClip dodgeSound;
    public AudioClip moveSound;

    private int currentLane = 1; // 0 = Left, 1 = Center, 2 = Right
    private Vector3[] lanes;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        // Set up lanes based on position
        lanes = new Vector3[]
        {
            new Vector3(-laneDistance, transform.position.y, 0),
            new Vector3(0, transform.position.y, 0),
            new Vector3(laneDistance, transform.position.y, 0)
        };
        transform.position = lanes[currentLane];

        playerStamina = GetComponent<PlayerStamina>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && currentLane > 0 && playerStamina.currentStamina > 1)
        {
            AudioSource.PlayClipAtPoint(moveSound, transform.position);
            currentLane--;
            transform.position = lanes[currentLane];
            playerStamina.DrainStamina(1); // drains stamina
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && currentLane < 2 && playerStamina.currentStamina > 1)
        {
            AudioSource.PlayClipAtPoint(moveSound, transform.position);
            currentLane++;
            transform.position = lanes[currentLane];
            playerStamina.DrainStamina(1); // drains stamina
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            PlayerShield shield = GetComponent<PlayerShield>(); 
            if (shield != null && shield.IsShieldActive())
            {
                shield.DeactivateShield(); // Consume shield
                Debug.Log("Shield saved you!");
                return; // Don’t trigger GameOver
            }
            PlayCrashSound();
            StartCoroutine(CameraShake(0.2f, 0.2f));
            Instantiate(dodgeEffectPrefab, transform.position, Quaternion.identity);
            Invoke(nameof(CallGameOver), 0.8f);
        }
    }
    public void OnDodge()
    {
        AudioSource.PlayClipAtPoint(dodgeSound, transform.position);
        if (playerStamina != null)
        {
            playerStamina.RestoreStamina(1f); // Restore 5 stamina on dodge
        }
    }

    void PlayCrashSound()
    {
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
    void CallGameOver()
    {
        GameManager.instance.GameOver();
    }
    public IEnumerator CameraShake(float duration, float magnitude)
    {
        Vector3 originalPos = Camera.main.transform.localPosition;

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            Camera.main.transform.localPosition = new Vector3(x, y, originalPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        Camera.main.transform.localPosition = originalPos;
    }
}
