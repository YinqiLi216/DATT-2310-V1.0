using UnityEngine;

public class TimerStart : MonoBehaviour
{
    public float totalTime;
    void Start()
    {
        Timer.Instance.totalTime = totalTime; // ���ó�ʼʱ��Ϊ60��
        Timer.timeFlowing = false;
    }
}
