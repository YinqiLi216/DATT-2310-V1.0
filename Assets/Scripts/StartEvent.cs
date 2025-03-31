using System;
using UnityEngine;

public class StartEvent : MonoBehaviour
{
    public string[] lines;
    public string moveCommand;
    // 静态变量，所有 StartEvent 实例共用这个标记
    private static bool eventTriggered = false;

    private GameObject player, panel;

    void Start()
    {
        // 如果还没有触发过，则初始化标记为未触发状态
        // （一般只会在第一次进入游戏时为 false）
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        if (GameObject.Find("MainDialoguePanel") != null)
        {
            panel = GameObject.Find("MainDialoguePanel");
        }
        // 初始化对话面板为隐藏状态
        panel.GetComponent<TextPresentor>().HidePanel(true);
    }

    void Update()
    {
        // 如果事件还没触发，则触发一次
        if (!eventTriggered)
        {
            panel.GetComponent<TextPresentor>().HidePanel(false);
            panel.GetComponent<TextPresentor>().lines = lines;
            eventTriggered = true; // 标记为已经触发

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
        }
    }
}
