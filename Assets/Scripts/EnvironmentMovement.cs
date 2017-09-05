using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentMovement : MonoBehaviour
{
    public float amountToMoveX;
    public float speed;
    private float currentPosY;
    private bool move;

    void Start()
    {
        currentPosY = gameObject.transform.position.y;
        move = true;
    }

    void Update()
    {
        if (move == true && gameObject.transform.position.y < currentPosY - amountToMoveX)
        {
            move = false;
        }

        if (move == false && gameObject.transform.position.y > currentPosY)
        {
            move = true;
        }

        if (move == false)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        else if (move == true)
        {
            transform.Translate(-Vector2.up * speed * Time.deltaTime);
        }
    }
}
