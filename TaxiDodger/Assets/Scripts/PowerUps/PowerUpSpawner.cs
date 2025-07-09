using UnityEngine;
using System.Collections.Generic;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject[] powerUpPrefabs; // Array of different power-ups
    public Transform[] spawnPoints;     // Lanes for power-ups
    public float spawnInterval = 8f;    // Seconds between power-ups

    private float spawnTimer = 0f;

    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            SpawnPowerUp();
            spawnTimer = 0f;
        }
    }

    void SpawnPowerUp()
    {
        // Get reference to RickshawSpawner
        RickshawSpawner rickshawSpawner = FindObjectOfType<RickshawSpawner>();

        if (rickshawSpawner == null || rickshawSpawner.lastRickshaw == null)
        {
            Debug.LogWarning("RickshawSpawner or lastRickshaw not found.");
            return;
        }

        // Get lane occupied by lastRickshaw
        int occupiedLane = GetLaneIndex(rickshawSpawner.lastRickshaw.transform.position);

        // Build a list of lanes not occupied
        List<int> availableLanes = new List<int>();
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (i != occupiedLane)
            {
                availableLanes.Add(i);
            }
        }

        if (availableLanes.Count == 0)
        {
            Debug.Log("No free lanes for PowerUp!");
            return; // All lanes occupied, skip spawning
        }

        // Pick a random available lane
        int randomLane = availableLanes[Random.Range(0, availableLanes.Count)];

        // Pick random power-up prefab
        GameObject powerUpPrefab = powerUpPrefabs[Random.Range(0, powerUpPrefabs.Length)];

        // Spawn power-up
        Instantiate(powerUpPrefab, spawnPoints[randomLane].position, Quaternion.identity);
    }

    int GetLaneIndex(Vector3 position)
    {
        // Find which spawn point (lane) is closest to given position
        int closestIndex = 0;
        float minDistance = Mathf.Infinity;

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            float distance = Vector3.Distance(position, spawnPoints[i].position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closestIndex = i;
            }
        }

        return closestIndex;
    }
}
