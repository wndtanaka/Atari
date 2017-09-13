using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetHighScore : MonoBehaviour
{
    private Text lastScore;

    void Start()
    {
        lastScore = GetComponent<Text>();
    }
    void Update()
    {
        Score();
    }
    void Score()
    {
        lastScore.text = "Your Score :" + GameManager.gm.lastScore; // just creating high score
    }
}