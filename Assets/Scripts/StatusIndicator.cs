using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusIndicator : MonoBehaviour
{

    [SerializeField]
    private RectTransform healthBar;
    [SerializeField]
    private Text healthText;

    public void SetHealth(int cur, int max)
    {
        float value = (float)cur / max;

        healthBar.localScale = new Vector3(value,1f,1f);
        healthText.text = cur + "/" + max + "HP";
    }
}
