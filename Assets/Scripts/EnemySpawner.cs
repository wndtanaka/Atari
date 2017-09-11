using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemySpawner;
    public GameObject enemyPrefab;

    private int waveTime;

    private void Start()
    {
        InvokeRepeating("Spawn", 0, 3);
    }
    void Spawn()
    {
        GameObject spawn = enemySpawner[Random.Range(0, enemySpawner.Length)];
        Instantiate(enemyPrefab,spawn.transform.position,spawn.transform.rotation);
    }

}
