using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform target;
    public GameObject[] enemySpawner;
    public GameObject enemyPrefab;

    private int waveTime;
    Player player;

    void Start()
    {
        InvokeRepeating("Spawn", 0, 1);        
    }
    void Update()
    {
        if (player.gameObject.activeInHierarchy == false)
        {
            CancelInvoke();
        }
    }
    void Spawn()
    {
        GameObject spawn = enemySpawner[Random.Range(0, enemySpawner.Length)];
        GameObject clone = Instantiate(enemyPrefab,spawn.transform.position,spawn.transform.rotation);
        EnemyAI enemyAI = clone.GetComponent<EnemyAI>();
        enemyAI.target = target;
    }

}
