using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float movementSpeed = 15f;
    public float jumpSpeed = 25f;

    private float canJump = 0;
    private Rigidbody2D rb;

    Animator anim;
    Transform player;
    bool facingRight = true;

    // Use this for initialization
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = transform.FindChild("Body");
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        if (Input.GetKey(KeyCode.A))
        {
            anim.SetFloat("Speed", movementSpeed);
            transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);
            //transform.eulerAngles = new Vector2(0, 180);
            if (facingRight)
            {
                Flip();
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            anim.SetFloat("Speed", movementSpeed);
            transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);
            if (!facingRight)
            {
                Flip();
            }
        }
        if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            anim.SetFloat("Speed", 0);
        }

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > canJump)
        {
            rb.velocity = new Vector2(0, jumpSpeed);
            canJump = Time.time + 0.5f;
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = player.localScale;
        theScale.x *= -1;
        player.localScale = theScale;
    }
}


