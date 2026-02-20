using UnityEngine;

public class WaveSpawnManagerExam04 : MonoBehaviour
{
    public Wave[] waveConfigurations;
    public WaveController waveController;

    public bool enableWaveCycling;

    private int currentWave = 0;
    private float waveEndTime = 0f;

    void Start()
    {
        currentWave = 0;
        waveController.StartWave(waveConfigurations[currentWave]);
        waveEndTime = Time.time + waveConfigurations[currentWave].waveInterval;
    }

    void Update()
    {
        if (waveController == null || waveConfigurations.Length == 0)
            return;

        if (!waveController.IsComplete() || Time.time < waveEndTime)
            return;

        currentWave++;

        if (currentWave >= waveConfigurations.Length)
        {
            if (enableWaveCycling)
            {
                currentWave = 0;
                waveController.StartWave(waveConfigurations[currentWave]);
                waveEndTime = Time.time + waveConfigurations[currentWave].waveInterval;
            }
            else
            {
                Debug.Log("All waves completed!");
            }
        }
        else
        {
            waveController.StartWave(waveConfigurations[currentWave]);
            waveEndTime = Time.time + waveConfigurations[currentWave].waveInterval;
        }
    }
}