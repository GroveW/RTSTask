using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Text currentTimeText;
    private float currentTime = 0.0f;

    private void Start()
    {
        InvokeRepeating(nameof(UpdateTimer), 0.0f, 1.0f);
    }

    private void UpdateTimer()
    {
        currentTime++;

        currentTimeText.text = "Time: " + currentTime;
    }
}
