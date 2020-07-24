using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies = new GameObject[4]; //4 enemy types
    private int waveNum = 1;
    private int numEnemies;
    private float bound = 25.0f;
    // Start is called before the first frame update
    void Start()
    {
        spawnEnemies(waveNum);
    }

    // Update is called once per frame
    void Update()
    {
        numEnemies = GameObject.FindGameObjectsWithTag("FireEnemy").Length + GameObject.FindGameObjectsWithTag("IceEnemy").Length + GameObject.FindGameObjectsWithTag("LightningEnemy").Length + GameObject.FindGameObjectsWithTag("ArcaneEnemy").Length;
        if (numEnemies == 0)
        {
            waveNum++;
            spawnEnemies(waveNum);
        }
    }

    void spawnEnemies(int wave)
    {
        int enemyType;
        //spawn enemies equal to wave Num
        for (int i = 0; i < wave; i++)
        {
            enemyType = Random.Range(0, 3);
            Instantiate(enemies[enemyType], generateSpawnPos(), enemies[enemyType].transform.rotation); 
        }
    }

    private Vector3 generateSpawnPos ()
    {
        float spawnPosX = Random.Range(-bound, bound);
        float spawnPosZ = Random.Range(-bound, bound);
        return new Vector3(spawnPosX, 1.5f, spawnPosZ);
    }
}
