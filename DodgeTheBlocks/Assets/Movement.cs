using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float maxStamina = 20f;
    public float currentStamina = 10f;
    public float moveUsed = 0f;
    public float moveSpeed = 5f;

    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float movement = inputX * moveSpeed * Time.deltaTime;

        if (Mathf.Abs(movement) <= currentStamina)
        {
            transform.Translate(movement, 0, 0);
            currentStamina -= Mathf.Abs(movement);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            GameManager.instance.GameOver();
        }
    }
    public void GainMovement(float amount)
    {
        currentStamina = Mathf.Min(currentStamina + amount, maxStamina);
    }

}

