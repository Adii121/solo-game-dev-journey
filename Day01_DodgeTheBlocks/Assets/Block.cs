using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public bool hasHitPlayer = false;
    private bool hasScored = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            hasHitPlayer = true;
        }
    }

    void OnBecameInvisible()
    {
        if (!hasHitPlayer && !hasScored)
        {
            hasScored = true;
        }

        Destroy(gameObject); // Destroy block immediately after it leaves screen
    }
}
