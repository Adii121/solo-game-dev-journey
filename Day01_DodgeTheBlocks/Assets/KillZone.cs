using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Block"))
        {
            Block block = other.GetComponent<Block>();
            if (block != null && !block.hasHitPlayer)
            {
                GameManager.instance.IncreaseScore(1);
            }

            Destroy(other.gameObject);
        }
    }
}
