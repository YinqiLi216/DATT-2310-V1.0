using System;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float totalTime;
    public static float globalRemainTime;
    public static Boolean timeFlowing, initial;
    public static Timer Instance;

    private void Awake()
    {
        // 确保只有一个实例
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 场景切换时不销毁
            if (!initial)
            {
                globalRemainTime = totalTime;
                timeFlowing = false;
            }
            initial = true;
        }
        else
        {
            Destroy(gameObject); // 如果已存在实例，销毁新实例
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timeFlowing) {
            if (Input.GetKey(KeyCode.Space))
            {
                globalRemainTime -= 20 * Time.deltaTime;
            }
            else {
                globalRemainTime -= Time.deltaTime;
            }
        }
        if (globalRemainTime <= 0) {
            timeFlowing = false;
        }
    }

    public float getRemainingTime() { 
        return globalRemainTime;
    }
}
