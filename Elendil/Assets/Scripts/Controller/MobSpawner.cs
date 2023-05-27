using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    public GameObject mobPrefab;  // Префаб моба, который вы хотите спавнить
    public float waveDelay = 5f;  // Задержка между волнами спауна мобов
    public float spawnDelay = 1f; // Задержка между спаунами мобов
    public int maxSpawnCount = 10; // Максимальное количество спаунов мобов
    public int wavesCount = 3;    // Количество волн спауна мобов

    private BoxCollider2D spawnArea; // Ссылка на компонент Box Collider 2D
    private int currentWave;         // Текущая волна спауна
    private int spawnedCount;        // Количество спаунов в текущей волне

  private void Start()
    {
        spawnArea = GetComponent<BoxCollider2D>();
        InvokeRepeating("SpawnWave", 0f, waveDelay);
    }

    private void SpawnWave()
    {
        currentWave++;
        spawnedCount = 0;
        InvokeRepeating("SpawnMob", 0f, spawnDelay);
        if (currentWave >= wavesCount)
        {
            CancelInvoke("SpawnWave");
        }
    }

    private void SpawnMob()
    {
        if (spawnedCount < maxSpawnCount)
        {
            Vector2 spawnPoint = GetRandomSpawnPoint();
            Instantiate(mobPrefab, spawnPoint, Quaternion.identity);
            spawnedCount++;
        }
        else
        {
            CancelInvoke("SpawnMob");
        }
    }

    private Vector2 GetRandomSpawnPoint()
    {
        Vector2 size = spawnArea.bounds.size;
        Vector2 center = spawnArea.bounds.center;
        float randomX = Random.Range(-size.x / 2f, size.x / 2f);
        float randomY = Random.Range(-size.y / 2f, size.y / 2f);
        return new Vector2(center.x + randomX, center.y + randomY);
    }
}
