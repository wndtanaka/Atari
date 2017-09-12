using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    private Text scoreBoard;
    private Enemy enemy;

    void Start()
    {
        scoreBoard = GetComponent<Text>();
        enemy = GetComponent<Enemy>();
    }
    void Update()
    {
        Score();
    }
    void Score()
    {
        scoreBoard.text = "Score :";
    }
}
