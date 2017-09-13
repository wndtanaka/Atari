using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public int spawnDelay = 3;

    public int score;
    public int lastScore;
    public int lives = 3;

    public Transform playerPrefab;
    public Transform spawnPoint;
    public Transform spawnPrefab;
    public static Player player;

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
        player.gameObject.SetActive(true);
        player.Reset();

        //Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
        Transform spawnParticles = Instantiate(spawnPrefab, spawnPoint.position, spawnPoint.rotation);
        Destroy(spawnParticles.gameObject, 1f);
    }

    public static void KillPlayer(Player p)
    {
        // Reset the player
        //Destroy(p.gameObject);
        p.gameObject.SetActive(false);
        gm.StartCoroutine(gm.RespawnPlayer());
        p.playerStats.curHealth = p.playerStats.maxHealth;
        gm.lives--;
        if (gm.lives <= 0)
        {
            gm.lastScore = gm.score;
            SceneManager.LoadScene("GameOver");
        }
    }

    public static void KillEnemy(Enemy e)
    {
        gm._KillEnemy(e);
        gm.score += 10;
    }

    public void _KillEnemy(Enemy enemy)
    {
        Transform part = Instantiate(enemy.deathParticles, enemy.transform.position, Quaternion.identity);
        Destroy(enemy.gameObject);
        Destroy(part.gameObject, 0.5f);
    }
}
