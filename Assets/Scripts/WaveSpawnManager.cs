using UnityEngine;

public class WaveSpawnManager : MonoBehaviour
{
    public Wave[] waveConfigs;
    public WaveController waveController;

    private int currentWaveIndex = 0;

    void Start()
    {
        waveController.ChangeWave(waveConfigs[0]);
    }

    void Update()
    {
        if (waveController.IsCompleted())
        {
            currentWaveIndex++;

            if (currentWaveIndex < waveConfigs.Length)
            {
                waveController.ChangeWave(waveConfigs[currentWaveIndex]);
            }
            else
            {
                Debug.Log("All done");
            }
        }
    }
}