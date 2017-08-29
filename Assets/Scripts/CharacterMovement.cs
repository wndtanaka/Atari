using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

    private float inputH;
    private float inputV;
    public float movementSpeed = 10f;
    private Rigidbody2D rigid;
	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        inputH = Input.GetAxis("Horizontal") * Time.deltaTime * movementSpeed;

        transform.Translate(inputH, 0, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigid.velocity = new Vector2(0,30f);
        }
    }
}
