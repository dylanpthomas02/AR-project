using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text text;

    float startTime = 30f;
    float currentTime;

    void Start()
    {
        currentTime = startTime;
        text.text = currentTime.ToString();
    }

    void Update()
    {
        if (currentTime <= 0)
        {
            GameManager.instance.GameOver();
            return;
        }
        else
        {
            currentTime -= Time.deltaTime;
            text.text = currentTime.ToString("F1");
        }
    }
}
