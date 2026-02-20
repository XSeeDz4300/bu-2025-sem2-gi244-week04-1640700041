using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // [1] declare a public GameObject array for animal prefabs
    public GameObject[] animalPrefabs;
    // [2] declare a public int variable for animal index for testing instantiation
    private int animalIndex;
    public float spawnRangeX = 15f;
    public float spawnRangeZ = 15f;

    void Start()
    {
        InvokeRepeating(nameof(Spawn), 1f, 1f);
    }

    void Spawn()
    {
        animalIndex = Random.Range(0, animalPrefabs.Length);

        Vector3 spawnPos = new Vector3(
            Random.Range(-spawnRangeX, spawnRangeX),
            transform.position.y,
            Random.Range(-spawnRangeZ, spawnRangeZ)
        );
        Instantiate(
            animalPrefabs[animalIndex],
            spawnPos,
            animalPrefabs[animalIndex].transform.rotation
        );
    }
}
