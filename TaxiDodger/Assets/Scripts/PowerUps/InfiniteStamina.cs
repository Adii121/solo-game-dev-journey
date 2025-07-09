using UnityEngine;

public class InfiniteStamina : MonoBehaviour
{
    public float duration = 5f; // Duration of effect

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStamina playerStamina = other.GetComponent<PlayerStamina>();

            if (playerStamina != null)
            {
                // Start infinite stamina
                playerStamina.StartCoroutine(playerStamina.InfiniteStamina(duration));
            }

            Destroy(gameObject); // Remove the power-up from the scene
        }
    }
}
