using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager gm;
    public int spawnDelay = 3;

    public Transform playerPrefab;
    public Transform spawnPoint;
    public Transform spawnPrefab;

    private void Start()
    {
        if(gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>(); ;
        }
    }

    public IEnumerator RespawnPlayer()
    {
        Debug.Log("Respawning");
        yield return new WaitForSeconds(spawnDelay);

        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
        Instantiate(spawnPrefab,spawnPoint.position, spawnPoint.rotation);
    }

    public static void Kill(Player p)
    {
        Destroy(p.gameObject);
        gm.StartCoroutine(gm.RespawnPlayer());
    }
}
