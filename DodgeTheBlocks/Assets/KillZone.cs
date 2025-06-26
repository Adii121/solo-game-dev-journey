using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    public float movePerDodge = 5f;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Block"))
        {
            Block block = other.GetComponent<Block>();
            if (block != null && !block.hasHitPlayer)
            {
                GameManager.instance.IncreaseScore(1);
                Movement player = FindObjectOfType<Movement>();
                if (player != null)
                {
                    player.GainMovement(movePerDodge);
                }
            }

            Destroy(other.gameObject);
        }
    }
}
