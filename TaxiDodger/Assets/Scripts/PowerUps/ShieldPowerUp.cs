using UnityEngine;

public class ShieldPowerUp : MonoBehaviour
{
    public float staminaCost = 2f; // Cost to activate shield
    public float shieldDuration = 5f; // How long shield lasts (optional)
    public AudioClip pickupSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStamina stamina = other.GetComponent<PlayerStamina>();
            PlayerShield shield = other.GetComponent<PlayerShield>();

            if (stamina != null && shield != null)
            {
                if (stamina.currentStamina >= staminaCost)
                {
                    AudioSource.PlayClipAtPoint(pickupSound, transform.position);
                    // Deduct stamina and activate shield
                    stamina.DrainStamina(staminaCost);
                    shield.ActivateShield(shieldDuration);

                    Destroy(gameObject); // Remove powerup
                }
                else
                {
                    Debug.Log("Not enough stamina for shield!");
                }
            }
        }
    }
}
