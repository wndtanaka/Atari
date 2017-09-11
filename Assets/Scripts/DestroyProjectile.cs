using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyProjectile : MonoBehaviour {

    public Transform partPrefab;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GameObject.FindGameObjectWithTag("Enemy"))
        {
            Destroy(this.gameObject);
            Transform part = Instantiate(partPrefab, transform.position, transform.rotation);
            Destroy(part.gameObject, 0.5f);
        }

        if (GameObject.FindGameObjectWithTag("Obstacle"))
        {
            Destroy(this.gameObject);
            Transform part = Instantiate(partPrefab, transform.position, transform.rotation);
            Destroy(part.gameObject,0.5f);
        }
    }
}
