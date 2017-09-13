using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [System.Serializable]
    public class EnemyStats
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
    int damage = 5;
    public EnemyStats enemyStats = new EnemyStats();
    public static int score = 0;

    public Transform deathParticles;

    [Header("Optional")]
    [SerializeField]
    private StatusIndicator statusIndicator;

    void Start()
    {
        enemyStats.Init();

        if (statusIndicator != null)
        {
            statusIndicator.SetHealth(enemyStats.curHealth, enemyStats.maxHealth);
        }
    }
    void Update()
    {
        if (GameManager.gm.score >= 100) // damage modifier
        {
            damage = 10;
        }
        if (GameManager.gm.score >= 250)
        {
            damage = 15;
        }
        if (GameManager.gm.score >= 500)
        {
            damage = 20;
        }
        if (GameManager.gm.score >= 1000)
        {
            damage = 25;
        }
    }
    public void DamageEnemy(int damage)
    {
        enemyStats.curHealth -= damage;
        if (enemyStats.curHealth <= 0)
        {
            GameManager.KillEnemy(this);
            score++;
        }
        if (statusIndicator != null)
        {
            statusIndicator.SetHealth(enemyStats.curHealth, enemyStats.maxHealth);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        // enemies will self destruct when hit player, and deal damage to player
        Player player = collision.collider.GetComponent<Player>();
        if (player != null)
        {
            player.DamagePlayer(damage);
            DamageEnemy(999);
        }
    }
}
