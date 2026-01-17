using System;
using Unity.VisualScripting;
using UnityEngine;

public class NotedSpawner : MonoBehaviour
{
    public GameObject notePrefab;
    public Transform[] lanes;
    public float spawnY = 6f;
    public float spawnInterval = 0.6f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     InvokeRepeating(nameof(SpawnNote), 1f, spawnInterval);   
    }

    // Update is called once per frame
    void SpawnNote()
    {
        int laneIndex = UnityEngine.Random.Range(0, lanes.Length);

        Vector3 spawnPos = lanes[laneIndex].position;
        spawnPos.y = spawnY;

        Instantiate(notePrefab, spawnPos, Quaternion.identity);
    }
}
