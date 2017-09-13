using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    int damage= 100;
    public float fireRate = 10;
    public LayerMask whatToHit;
    public Transform bulletTrailPrefab;
    public Transform muzzlePrefab;

    float timeToFire = 0;
    Transform firePoint;

    // Use this for initialization
    void Awake()
    {
        firePoint = transform.FindChild("FirePoint");
            }

    // Update is called once per frame
    void Update()
    {
        if (fireRate == 0) // for single burst
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }
        else
        {
            if (Input.GetButton("Fire1") && Time.time > timeToFire) // for continuos shooting
            {
                timeToFire = Time.time + 1 / fireRate;
                Shoot();
            }
        }
        if (GameManager.gm.score >= 100) // damage modifier
        {
            damage = 50;
        }
        if (GameManager.gm.score >= 250)
        {
            damage = 34;
        }
        if (GameManager.gm.score >= 500)
        {
            damage = 25;
        }
        if (GameManager.gm.score >= 1000)
        {
            damage = 20;
        }
        if (GameManager.gm.score >= 1500)
        {
            damage = 15;
        }
        if (GameManager.gm.score >= 2000)
        {
            damage = 10;
        }
    }
    void Shoot()
    {
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition, 100f, whatToHit);
        StartCoroutine("Effect"); // instantiating projectile prefab
        if (hit.collider != null)
        {
            Enemy enemy = hit.collider.GetComponent<Enemy>();
            if (enemy != null)
            {
                    enemy.DamageEnemy(damage);
            }
        }
    }
    IEnumerator Effect()
    {
        Transform trail = Instantiate(bulletTrailPrefab, firePoint.position, firePoint.rotation) as Transform;
        Transform clone = Instantiate(muzzlePrefab, firePoint.position, firePoint.rotation) as Transform;
        clone.parent = firePoint;
        float size = Random.Range(0.6f, 1f);
        clone.localScale = new Vector3(size, size, size);
        yield return 0;
        Destroy(clone.gameObject);
    }
}
