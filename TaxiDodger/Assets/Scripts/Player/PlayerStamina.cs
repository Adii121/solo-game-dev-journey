using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerStamina : MonoBehaviour
{
    public float maxStamina = 5f;       // Maximum stamina
    public float currentStamina;        // Current stamina
    public Image staminaBarFill;        // Reference to UI fill image
    public bool isInfinite = false;

    void Start()
    {
        //currentStamina = maxStamina;
        UpdateStaminaUI();
    }

    public void DrainStamina(float amount)
    {
        if (isInfinite) return; // Don’t drain if infinite

        currentStamina -= amount;
        currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);
        UpdateStaminaUI();
    }

    public void RestoreStamina(float amount)
    {
        currentStamina += amount;
        currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);
        UpdateStaminaUI();
    }

    void UpdateStaminaUI()
    {
        if (staminaBarFill != null)
        {
            staminaBarFill.fillAmount = currentStamina / maxStamina;
        }
    }
    public IEnumerator InfiniteStamina(float duration)
    {
        isInfinite = true; // Enable infinite mode
        float timer = 0f;

        while (timer < duration)
        {
            currentStamina = maxStamina; // Keep refilling
            UpdateStaminaUI();
            timer += Time.deltaTime;
            yield return null;
        }

        isInfinite = false; // Back to normal
    }

}
