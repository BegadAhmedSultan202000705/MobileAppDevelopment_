using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public MonsterFormation[] waves; // Array of waves (each wave is a formation)
    public Transform spawnParent; // Parent object for spawned monsters
    public float waveDelay = 5f; // Delay between waves

    private int currentWaveIndex = 0; // Index of the current wave
    private int remainingMonsters = 0; // Counter for remaining monsters in a wave

    // Start the first wave
    void Start()
    {
        StartNextWave();
    }

    // Function to start the next wave
    void StartNextWave()
    {
        if (currentWaveIndex < waves.Length)
        {
            SpawnWave(waves[currentWaveIndex]);
            currentWaveIndex++;
        }
        else
        {
            // All waves are completed, you can handle end of game logic here
            Debug.Log("All waves completed!");
        }
    }

    // Function to spawn a wave based on the given formation
    void SpawnWave(MonsterFormation formation)
    {
        remainingMonsters = formation.numberOfMonsters;

        for (int i = 0; i < formation.numberOfMonsters; i++)
        {
            Vector3 spawnPosition = formation.spawnPositions[i % formation.spawnPositions.Length];
            GameObject monster = Instantiate(formation.monsterPrefab, spawnPosition, Quaternion.identity, spawnParent);

            // Get the MonsterController component and subscribe to the OnDestroyed event
            MonsterController monsterController = monster.GetComponent<MonsterController>();
            monsterController.OnDestroyed += HandleMonsterDestroyed;
        }
    }

    // Function to handle monster destruction
    void HandleMonsterDestroyed()
    {
        remainingMonsters--;

        // Check if all monsters in the wave are destroyed
        if (remainingMonsters <= 0)
        {
            // Delay the start of the next wave
            Invoke("StartNextWave", waveDelay);
        }
    }
}
