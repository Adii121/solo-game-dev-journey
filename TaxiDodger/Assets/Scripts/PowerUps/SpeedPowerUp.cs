using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour
{
    public float speedDecrease = 2f;
    public float staminaCost = 6f;  // Cost to activate
    public GameObject pickupEffect;
    public AudioClip pickupSound;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStamina playerStamina = other.GetComponent<PlayerStamina>();
            if (playerStamina != null && playerStamina.currentStamina >= staminaCost)
            {
                Instantiate(pickupEffect, transform.position, Quaternion.identity);
                AudioSource.PlayClipAtPoint(pickupSound, transform.position);
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
