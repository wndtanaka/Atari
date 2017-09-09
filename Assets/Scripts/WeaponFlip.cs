using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFlip : MonoBehaviour
{

    SpriteRenderer sprite;

    // Use this for initialization
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
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
