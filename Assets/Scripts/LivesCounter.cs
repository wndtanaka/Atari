using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesCounter : MonoBehaviour
{
    private Text lives;

    void Start()
    {
        lives = GetComponent<Text>();
    }
    void Update()
    {
        Lives();
    }
    void Lives()
    {
        lives.text = "Lives: " + GameManager.gm.lives;
    }
}
