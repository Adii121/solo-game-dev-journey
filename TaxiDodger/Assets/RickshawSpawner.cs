using UnityEngine;
using System.Collections;

public class RickshawSpawner : MonoBehaviour
{
    public GameObject rickshawPrefab;
    public Transform[] spawnPoints;

    public float minSpacing = 3.5f; // tighter spacing at low speed
    public float maxSpacing = 5.5f; // wider spacing at high speed

    private GameObject lastRickshaw;

    void Update()
    {
        if (rickshawPrefab == null || spawnPoints.Length == 0) return;

        float currentSpeed = GameManager.instance.blockFallSpeed;

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

        lastRickshaw = Instantiate(rickshawPrefab, spawnPoint.position, Quaternion.identity);
    }
}
