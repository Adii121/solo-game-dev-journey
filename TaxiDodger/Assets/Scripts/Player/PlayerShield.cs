using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    public GameObject shieldVisual; // assign a visual effect (sprite or particle)

    private bool shieldActive = false;

    public void ActivateShield(float duration)
    {
        if (!shieldActive)
        {
            shieldActive = true;
            shieldVisual.SetActive(true); // show shield effect
            Debug.Log("Shield activated!");

            if (duration > 0f)
            {
                Invoke(nameof(DeactivateShield), duration);
            }
        }
    }

    public void DeactivateShield()
    {
        shieldActive = false;
        shieldVisual.SetActive(false);
        Debug.Log("Shield deactivated.");
    }

    public bool IsShieldActive()
    {
        return shieldActive;
    }
}
