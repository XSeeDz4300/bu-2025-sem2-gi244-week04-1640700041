using UnityEngine;

public class WaveController : MonoBehaviour
{
    public Wave currentWave;
    public Transform[] spawnPoints;

    private int enemySpawned = 0;
    private float nextSpawnTime = 0;

    void Update()
    {
        var t = Time.time;
        if (t > nextSpawnTime && enemySpawned < currentWave.enemyCount)
        {
            Spawn();
            enemySpawned += 1;
            nextSpawnTime = Time.time + currentWave.spawnInterval;
        }
    }

    public void ChangeWave(Wave wave)
    {
        currentWave = wave;

        enemySpawned = 0;
        nextSpawnTime = Time.time;
    }

    public bool IsCompleted()
    {
        return enemySpawned >= currentWave.enemyCount;
    }

    void Spawn()
    {
        //animalIndex = Random.Range(0, animalPrefabs.Length);
        //Vector3 spawnPos = new(
        //    Random.Range(-spawnRangeX, spawnRangeX),
        //    transform.position.y,
        //    transform.position.z
        //);
        //Instantiate(
        //    animalPrefabs[animalIndex],
        //    spawnPos,
        //    animalPrefabs[animalIndex].transform.rotation
        //);

        int enemyIndex = Random.Range(0, currentWave.enemyPrefabs.Length);
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(
            currentWave.enemyPrefabs[enemyIndex],
            spawnPoints[spawnPointIndex].position,
            currentWave.enemyPrefabs[enemyIndex].transform.rotation
        );
    }
}