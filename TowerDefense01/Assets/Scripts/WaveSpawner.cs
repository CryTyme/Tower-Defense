using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //allows for ui manipulation

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f; //creates countdown float

    public Text waveCountDownText;

    private int waveIndex = 0;

    void Update()
    {
        if (countdown <= 0f) //coutdown to zero and then announcewave 
        {
            StartCoroutine(SpawnWave());
          countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;

        waveCountDownText.text = Mathf.Round(countdown).ToString(); //cuts off decimal places
    }

    IEnumerator SpawnWave ()
    {
        waveIndex++;

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
            
        }

        
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

}
