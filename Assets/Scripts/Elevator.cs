using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour {

    public float amountToMoveY;
    public float speed;
    private float currentPosY;
    private bool move;

    void Start()
    {
        currentPosY = gameObject.transform.position.y;
        move = false;
    }

    void Update()
    {
        if (move == false && gameObject.transform.position.y < currentPosY - amountToMoveY)
        {
            move = true;
        }

        if (move == true && gameObject.transform.position.y > currentPosY)
        {
            move = false;
        }

        if (move == false)
        {
            transform.Translate(-Vector2.up * speed * Time.deltaTime);
        }
        else if (move == true)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
    }
}
