using UnityEngine;

public class InfiniteStamina : MonoBehaviour
{
    public float duration = 5f; // Duration of effect
    public GameObject pickupEffect;
    public AudioClip pickupSound;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStamina playerStamina = other.GetComponent<PlayerStamina>();

            if (playerStamina != null)
            {
                Instantiate(pickupEffect, transform.position, Quaternion.identity);
                AudioSource.PlayClipAtPoint(pickupSound, transform.position);
                // Start infinite stamina
                playerStamina.StartCoroutine(playerStamina.InfiniteStamina(duration));
            }

            Destroy(gameObject); // Remove the power-up from the scene
        }
    }
}
