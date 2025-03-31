using UnityEngine;

public class TimerStart : MonoBehaviour
{
    public float totalTime;
    void Start()
    {
        Timer.Instance.totalTime = totalTime; // 设置初始时间为60秒
        Timer.timeFlowing = false;
    }
}
