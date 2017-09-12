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

        public int damage = 25;

        public void Init()
        {
            curHealth = maxHealth;
        }
    }

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
        Player player = collision.collider.GetComponent<Player>();
        if (player != null)
        {
            player.DamagePlayer(enemyStats.damage);
            DamageEnemy(999);
        }
    }
}
