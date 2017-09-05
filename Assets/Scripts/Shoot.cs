using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public GameObject projectilePrefab;
    public float projectileSpeed = 30f;
    public float shootRate = 0.2f;
    private float shootTimer = 0f;

    void Start()
    {
    }

    void Update()
    {
        shootTimer += Time.deltaTime;

        if (Input.GetKey(KeyCode.Mouse0) && shootTimer >= shootRate)
        {
            Shooting();
            shootTimer = 0;
        }
    }
    void Shooting()
    {
        GameObject projectile = Instantiate(projectilePrefab);
        projectile.transform.position = transform.position;
        Rigidbody2D rigid = projectile.GetComponent<Rigidbody2D>();
        rigid.AddForce(transform.right * projectileSpeed, ForceMode2D.Impulse);
    }
}
