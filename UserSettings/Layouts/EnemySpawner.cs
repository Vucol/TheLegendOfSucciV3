using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static int EnemySurvive = 0;
    public Wave[] waves;
    public Transform START;
    public float waveRate = 0.2f;
    void Start()
    {
        StartCoroutine("SpawnEnemy");
    }
    public void Stop()
    {
        StopCoroutine("SpawnEnemy");
    }
    IEnumerator SpawnEnemy()
    {
        foreach(Wave wave in waves)
        {
            for(int i = 0; i < wave.count; i++)
            {
                GameObject.Instantiate(wave.enemyPrefeb, START.position, Quaternion.identity);
                EnemySurvive++;
                if(i != wave.count - 1)
                {
                    yield return new WaitForSeconds(wave.rate);
                }
            }
            while(EnemySurvive > 0)
            {
                yield return 0;
            }
            yield return new WaitForSeconds(waveRate);
        }
        while (EnemySurvive > 0)
        {
            yield return 0;
        }
        GameManager.Instance.Win();
    }
}
