using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public int spawnDelay = 3;

    public int score= 0;

    public Transform playerPrefab;
    public Transform spawnPoint;
    public Transform spawnPrefab;

    private void Start()
    {
        if (gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>(); ;
        }
    }

    public IEnumerator RespawnPlayer()
    {
        Debug.Log("Respawning");
        yield return new WaitForSeconds(spawnDelay);

        //Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
        Transform spawnParticles =  Instantiate(spawnPrefab, spawnPoint.position, spawnPoint.rotation);
        Destroy(spawnParticles.gameObject, 1f);
    }

    public static void KillPlayer(Player p)
    {
        // Reset the player
        //Destroy(p.gameObject);
        gm.StartCoroutine(gm.RespawnPlayer());
        p.Reset();
    }

    public static void KillEnemy(Enemy e)
    {
        gm._KillEnemy(e);
    }

    public void _KillEnemy(Enemy enemy)
    {
        Transform part = Instantiate(enemy.deathParticles, enemy.transform.position, Quaternion.identity);
        Destroy(enemy.gameObject);
        Destroy(part.gameObject, 0.5f);
    }
}
