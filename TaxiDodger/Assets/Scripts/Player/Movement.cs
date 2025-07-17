using UnityEngine;

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

    void Start()
    {
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
            GameManager.instance.GameOver();
        }
    }
    public void OnDodge()
    {
        Instantiate(dodgeEffectPrefab, transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(dodgeSound, transform.position);
        if (playerStamina != null)
        {
            playerStamina.RestoreStamina(1f); // Restore 5 stamina on dodge
        }
    }
}
