using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [System.Serializable]
    public class PlayerStats
    {
        public int maxHealth = 100;

        private int _curHealth;
        public int curHealth
        {
            get { return _curHealth; }
            set { _curHealth = Mathf.Clamp(value, 0, maxHealth); }
        }
        public void Init()
        {
            curHealth = maxHealth;
        }
    }

    public PlayerStats playerStats = new PlayerStats();

    public int fallBoundary = -20;

    // Record the position at Start()
    public Vector3 startPos;
    public Transform playerSpawner;

    [SerializeField]
    private StatusIndicator statusIndicator;

    private void Start()
    {
        
        playerStats.Init();
        if (statusIndicator != null)
        {
            statusIndicator.SetHealth(playerStats.curHealth, playerStats.maxHealth);
        }
    }
    void Update()
    {
        if (transform.position.y <= fallBoundary)
            DamagePlayer(9999999);
    }

    public void Reset()
    {
        startPos = playerSpawner.transform.position; 
        playerStats.curHealth = playerStats.maxHealth;
    }

    public void DamagePlayer(int damage)
    {
        playerStats.curHealth -= damage;
        if (playerStats.curHealth <= 0)
        {
            GameManager.KillPlayer(this);
        }
        statusIndicator.SetHealth(playerStats.curHealth, playerStats.maxHealth);
    }
}
