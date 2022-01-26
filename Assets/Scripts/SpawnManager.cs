using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject enemy;
    private float spawnRange = 9;
    public int enemyCount;
    public int waveNumber = 1;
    public GameObject powerUps;

    // Start is called before the first frame update
    void Start()
    {
        spawnEnemy(waveNumber);
        spawnPowerup();
    }

    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            spawnEnemy(waveNumber);
            spawnPowerup();
        }
    }


    void spawnEnemy(int numberOfEnemies)
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            Instantiate(enemy, GenerateRandomPos(), enemy.transform.rotation);
        }
    }

    private Vector3 GenerateRandomPos()
    {
        float spawnX = Random.Range(-spawnRange, spawnRange);
        float spawnZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnX, 0, spawnZ);

        return randomPos;
    }

    void spawnPowerup()
    {
        Instantiate(powerUps, GenerateRandomPos(), powerUps.transform.rotation);
    }
}
