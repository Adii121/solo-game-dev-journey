using UnityEngine;
using System.Collections;

public class RickshawSpawner : MonoBehaviour
{
    public GameObject rickshawPrefab;
    public Transform[] spawnPoints;

    public float minSpacing = 3.5f; // tighter spacing at low speed
    public float maxSpacing = 5.5f; // wider spacing at high speed

    public GameObject lastRickshaw;

    void Update()
    {
        if (rickshawPrefab == null || spawnPoints.Length == 0) return;

        float currentSpeed = GameManager.instance.rickshawSpeed;

        // Normalize speed between 0 and 1 for Lerp
        float normalizedSpeed = Mathf.InverseLerp(2f, 10f, currentSpeed); // adjust range as needed
        float dynamicSpacing = Mathf.Lerp(minSpacing, maxSpacing, normalizedSpeed);

        float cameraBottom = Camera.main.orthographicSize;
        if (lastRickshaw == null || lastRickshaw.transform.position.y < cameraBottom - dynamicSpacing)
        {
            SpawnRickshaw();
        }
    }

    void SpawnRickshaw()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];
        if (IsLaneOccupiedByPowerUp(spawnPoint.position))
        {
            // Skip spawning this frame
            return;
        }

        lastRickshaw = Instantiate(rickshawPrefab, spawnPoint.position, Quaternion.identity);
    }
    bool IsLaneOccupiedByPowerUp(Vector3 spawnPosition)
    {
        float laneCheckRadius = 1.8f; // Adjust based on lane width
        Collider2D[] hits = Physics2D.OverlapCircleAll(spawnPosition, laneCheckRadius);

        foreach (var hit in hits)
        {
            if (hit.CompareTag("PowerUp")) // Make sure your power-ups have this tag
            {
                return true;
            }
        }
        return false;
    }
}


