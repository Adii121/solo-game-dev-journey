using UnityEngine;

public class KillZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle")) // Make sure Rickshaw prefab is tagged as Obstacle
        {
            GameManager.instance.IncreaseScore(1);
            Destroy(other.gameObject);
        }
    }
}
