using System;
using UnityEngine;

public class TouchEventontroller : MonoBehaviour
{
    public string[] lines;
    public string moveCommand;
    private Boolean playerIn, triggered;
    private GameObject player, panel;
    public float forceMoveDuration = 10f; 
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerIn = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerIn = false;
        }
    }

   void Update()
{
    if (panel.GetComponent<TextPresentor>().IsHidden() && playerIn && triggered)
    {
        triggered = false;
        panel.GetComponent<TextPresentor>().HidePanel(false);
        panel.GetComponent<TextPresentor>().lines = lines;
        PlayerController playerC = player.GetComponent<PlayerController>();
        // 停止之前的移动命令
        playerC.StopMovingCommand();
        // 使用 ForceMove 来开始强制移动，传入方向和持续时间
        playerC.ForceMove(moveCommand, forceMoveDuration);
    }
}
}
