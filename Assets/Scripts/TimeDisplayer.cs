using System;
using TMPro;
using UnityEngine;

public class TimeDisplayer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float remainTime;
    public GameObject timeDisplayer;
    public TextMeshProUGUI timerText;
    void Start()
    {
        remainTime = Timer.globalRemainTime;
        UpdateTimerDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        remainTime = Timer.globalRemainTime;
        UpdateTimerDisplay();
    }

    private void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt((remainTime + 1) / 60f);
        int seconds = Mathf.FloorToInt((remainTime + 1) % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        timeDisplayer.SetActive(true);
    }
}
