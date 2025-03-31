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
        // ȷ��ֻ��һ��ʵ��
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // �����л�ʱ������
            if (!initial)
            {
                globalRemainTime = totalTime;
                timeFlowing = false;
            }
            initial = true;
        }
        else
        {
            Destroy(gameObject); // ����Ѵ���ʵ����������ʵ��
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
