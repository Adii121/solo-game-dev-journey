using UnityEngine;
using UnityEngine.UI;

public class PlayerStamina : MonoBehaviour
{
    public float maxStamina = 5f;    // Maximum stamina
    public float currentStamina;    // Current stamina
    public Image staminaBarFill;  // Reference to UI fill image

    void Start()
    {
        //currentStamina = maxStamina;
        UpdateStaminaUI();
    }

    void Update()
    {
        // Example: Drain stamina on movement
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            DrainStamina(Time.deltaTime * 2f);
        }
    }

    public void DrainStamina(float amount)
    {
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
            staminaBarFill.fillAmount = (float)currentStamina / maxStamina;
        }
    }
}
