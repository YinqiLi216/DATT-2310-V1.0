using System;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class StartEvent : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public string[] lines;
    public string moveCommand;
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
        panel.GetComponent<TextPresentor>().HidePanel(true);
    }

    void Update() {
        if (triggered) {
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
        }
    }
}