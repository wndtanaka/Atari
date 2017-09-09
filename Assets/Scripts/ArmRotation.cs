using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmRotation : MonoBehaviour
{
    SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position; // substracting the position  of the player from mouse position
        difference.Normalize(); // normalizing the vector.Meaning that all the sum of the vector will be equal to one
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg; // find the angle in degrees
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ);

        if (sprite != null)
        {
            if (Input.GetKey(KeyCode.A))
            {
                sprite.flipY = true;
                
            }
            if (Input.GetKey(KeyCode.D))
            {
                sprite.flipY = false;
            }
        }
    }
}
