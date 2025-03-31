using System;
using UnityEngine;
using UnityEngine.Events;

public class TimeEventController : MonoBehaviour
{
    public float timeTrigger;
    public string[] lines;
    public string moveCommand;
    public UnityEvent onTimeTrigger;  // 在 Inspector 中可以添加多个响应方法
    private Boolean triggered;
    private GameObject player, panel;

    void Start()
    {
        triggered = true;
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        if (GameObject.Find("MainDialoguePanel") != null)
        {
            panel = GameObject.Find("MainDialoguePanel");
        }
    }
    void Update()
    {
        if (Timer.globalRemainTime <= timeTrigger && triggered) {
            panel.GetComponent<TextPresentor>().HidePanel(false);
            panel.GetComponent<TextPresentor>().lines = lines;
            triggered = false;
            PlayerController playerC = player.GetComponent<PlayerController>();
            playerC.StopMovingCommand();
            if (moveCommand == "right")
            {
                playerC.rightCommand = true;
            }
            if (moveCommand == "left")
            {
                playerC.leftCommand = true;
            }
            
            // 触发 UnityEvent 中绑定的所有方法
            onTimeTrigger.Invoke();
        }
    }
}