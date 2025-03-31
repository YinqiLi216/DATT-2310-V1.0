using System;
using UnityEngine;

public class EventInteractionController : MonoBehaviour
{
    public string[] lines;
    public string moveCommand;
    private Boolean playerIn;
    private GameObject player, panel;
    void Start()
    {
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
        if (panel.GetComponent<TextPresentor>().IsHidden() && playerIn && Input.GetKeyUp(KeyCode.E)) {
            panel.GetComponent<TextPresentor>().HidePanel(false);
            panel.GetComponent<TextPresentor>().lines = lines;
            PlayerController playerC = player.GetComponent<PlayerController>();
            playerC.StopMovingCommand();
            if (moveCommand == "right") {
                playerC.rightCommand = true;
            }
            if (moveCommand == "left")
            {
                playerC.leftCommand = true;
            }
        }
    }
}
