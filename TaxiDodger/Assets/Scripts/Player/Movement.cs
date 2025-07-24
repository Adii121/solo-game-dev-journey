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
    public PlayerShield shield;
    BoxCollider2D playerCollider;

    private int currentLane = 1; // 0 = Left, 1 = Center, 2 = Right
    private Vector3[] lanes;
    private AudioSource audioSource;
    [SerializeField] private LayerMask obstacleLayer;

    // Swipe detection variables
    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;
    private bool isSwiping = false;
    public float swipeThreshold = 50f; // Minimum swipe distance in pixels

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

        shield = GetComponent<PlayerShield>();

        playerCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        // --- Keyboard Controls (Editor/PC) ---
        if (Input.GetKeyDown(KeyCode.LeftArrow) && currentLane > 0 && playerStamina.currentStamina > 1)
        {
            MoveLeft();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && currentLane < 2 && playerStamina.currentStamina > 1)
        {
            MoveRight();
        }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                startTouchPosition = touch.position;
                isSwiping = true;
            }
            else if (touch.phase == TouchPhase.Ended && isSwiping)
            {
                endTouchPosition = touch.position;
                DetectSwipe();
                isSwiping = false;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            if (shield != null && shield.IsShieldActive())
            {
                shield.DeactivateShield(); // Consume shield
                Debug.Log("Shield saved you!");
                return; // Don�t trigger GameOver
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

    public void MoveLeft()
    {
        int targetLane = currentLane - 1;
        if (targetLane >= 0)
        {
            if(shield != null && shield.IsShieldActive() && IsObstacleInLane(targetLane))
            {
                AudioSource.PlayClipAtPoint(moveSound, transform.position);
                PlayCrashSound();
                StartCoroutine(CameraShake(0.2f, 0.2f));
                shield.DeactivateShield();
                return;
            }
            AudioSource.PlayClipAtPoint(moveSound, transform.position);
            currentLane = targetLane;
            transform.position = lanes[currentLane];
            playerStamina.DrainStamina(1); // drains stamina
        }
    }

    public void MoveRight()
    {
        int targetLane = currentLane + 1;
        if (targetLane <= 2)
        {
            if (shield != null && shield.IsShieldActive() && IsObstacleInLane(targetLane))
            {
                AudioSource.PlayClipAtPoint(moveSound, transform.position);
                PlayCrashSound();
                StartCoroutine(CameraShake(0.2f, 0.2f));
                shield.DeactivateShield();
                return;
            }
            AudioSource.PlayClipAtPoint(moveSound, transform.position);
            currentLane = targetLane;
            transform.position = lanes[currentLane];
            playerStamina.DrainStamina(1); // drains stamina
        }
    }
    void DetectSwipe()
    {
        Vector2 swipeDelta = endTouchPosition - startTouchPosition;

        if (Mathf.Abs(swipeDelta.x) > swipeThreshold && Mathf.Abs(swipeDelta.x) > Mathf.Abs(swipeDelta.y))
        {
            if (swipeDelta.x < 0 && currentLane > 0 && playerStamina.currentStamina > 1)
            {
                MoveLeft();
            }
            else if (swipeDelta.x > 0 && currentLane < 2 && playerStamina.currentStamina > 1)
            {
                MoveRight();
            }
        }
    }
    bool IsObstacleInLane(int targetLane)
    {
        Vector3 checkPos = lanes[targetLane];

        Vector2 boxSize = playerCollider.size;
        Vector2 boxOffset = playerCollider.offset;

        Vector2 boxCenter = new Vector2(checkPos.x, transform.position.y) + boxOffset;

        Collider2D hit = Physics2D.OverlapBox(
            boxCenter,
            boxSize,
            0f,
            obstacleLayer
        );

        return hit != null && hit.CompareTag("Obstacle");
    }
}
