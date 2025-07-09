using UnityEngine;

public class PowerUpMovement : MonoBehaviour
{
    void Update()
    {
        // Move downward at same speed as taxis
        transform.Translate(Vector2.down * GameManager.instance.rickshawSpeed * Time.deltaTime);
    }
}
