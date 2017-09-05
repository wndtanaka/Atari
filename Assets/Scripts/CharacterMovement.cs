using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float movementSpeed = 15f;
    public float jumpSpeed = 25f;

    private float canJump = 0;
    private Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 180);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > canJump)
        {
            rb.velocity = new Vector2(0, jumpSpeed);
            canJump = Time.time + 0.5f;
        }
    }
}


