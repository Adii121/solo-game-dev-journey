using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject blockPrefab;
    public float spawnInterval = 1f;
    public float spawnRangeX = 8f;
    public float top = 10f;

    void Start()
    {
        InvokeRepeating("SpawnBlock", 1f, spawnInterval);
    }

    void SpawnBlock()
    {
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector2 spawnPosition = new Vector2(randomX, top);
        GameObject block = Instantiate(blockPrefab, spawnPosition, Quaternion.identity);
    }
}
