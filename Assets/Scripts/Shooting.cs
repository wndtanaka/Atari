using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float fireRate = 0;
    public int damage = 10;
    public LayerMask whatToHit;
    public Transform bulletTrailPrefab;
    public Transform muzzlePrefab;

    float timeToFire = 0;
    Transform firePoint;
    
    // Use this for initialization
    void Awake()
    {
        firePoint = transform.FindChild("FirePoint");
        if (firePoint == null)
        {
            Debug.LogError("FirePoint not assigned");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (fireRate == 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }
        else
        {
            if (Input.GetButton("Fire1") && Time.time > timeToFire)
            {
                timeToFire = Time.time + 1 / fireRate;
                Shoot();
            }
        }
    }
    void Shoot()
    {
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition,100f,whatToHit);
        StartCoroutine("Effect");
        Debug.DrawLine(firePointPosition, (mousePosition-firePointPosition)*100);
        if (hit.collider != null)
        {
            Debug.DrawLine(firePointPosition, hit.point, Color.red);
            Enemy enemy = hit.collider.GetComponent<Enemy>();
            if(enemy != null)
            {
                enemy.DamageEnemy(damage);
                Debug.Log("You hit" + hit.collider.name + " and did " + damage + " damage.");

            }
        }
    }
    IEnumerator Effect()
    {
        Transform trail = Instantiate(bulletTrailPrefab,firePoint.position,firePoint.rotation) as Transform;
        Transform clone = Instantiate(muzzlePrefab, firePoint.position, firePoint.rotation) as Transform;
        clone.parent = firePoint;
        float size = Random.Range(0.6f,1f);
        clone.localScale = new Vector3(size,size,size);
        yield return 0;
        Destroy(clone.gameObject);
    }
}
