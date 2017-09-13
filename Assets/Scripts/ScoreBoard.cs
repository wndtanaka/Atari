﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    private Text scoreBoard;

    void Start()
    {
        scoreBoard = GetComponent<Text>();
    }
    void Update()
    {
        Score();
    }
    void Score()
    {
        scoreBoard.text = "Score :" + GameManager.gm.score;
    }
}
