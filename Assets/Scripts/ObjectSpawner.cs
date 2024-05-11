using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject[] objects;

    [SerializeField] private float maxSpawnDelay = 2f;
    private float spawnDelay = 0f;

    void Update()
    {
        if (!GameManager.Instance.gameRunning) return;

        spawnDelay -= Time.deltaTime;

        if (spawnDelay < 0.01f)
        {
            int randomIndex = Random.Range(0, spawnPoints.Length);
            Transform point = spawnPoints[randomIndex];

            randomIndex = Random.Range(0, objects.Length);
            GameObject obj = objects[randomIndex];

            Instantiate(obj, point.position, Quaternion.identity);
            spawnDelay = maxSpawnDelay;
            GameManager.Instance.IncrementScore();
        }
    }
}
