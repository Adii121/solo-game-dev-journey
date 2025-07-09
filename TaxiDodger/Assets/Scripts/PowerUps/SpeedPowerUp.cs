using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour
{
    public float speedDecrease = 2f;
    public float staminaCost = 3f;  // Cost to activate

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStamina playerStamina = other.GetComponent<PlayerStamina>();
            if (playerStamina != null && playerStamina.currentStamina >= staminaCost)
            {
                // Spend stamina
                playerStamina.DrainStamina(staminaCost);

                // Apply effect
                GameManager.instance.ApplyPermanentSlowdown(speedDecrease);
                if (GameManager.instance.rickshawSpeed < GameManager.instance.minSpeed)
                {
                    GameManager.instance.rickshawSpeed = GameManager.instance.minSpeed;
                }
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("Not enough stamina for this power-up!");
            }
        }
    }
}
