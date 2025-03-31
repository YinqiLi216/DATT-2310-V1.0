using System;
using UnityEngine;

public class BenchInteracting : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject sittingPlayer;
    private Boolean playerIn, sitting;
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
        sitting = false;
        sittingPlayer.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("PlayerIn");
            playerIn = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("PlayerOut");
            playerIn = false;
        }
    }

    void Update()
    {
        if (panel.GetComponent<TextPresentor>().IsHidden() && playerIn && Input.GetKeyUp(KeyCode.E))
        {
            PlayerController playerC = player.GetComponent<PlayerController>();
            if (playerC.HasMovingCommand()) {
                return;            
            }
            sitting = !sitting;
            playerC.sitting = sitting;
            if (sitting)
            {
                sittingPlayer.SetActive(true);
            }
            else
            {
                sittingPlayer.SetActive(false);
                player.transform.position = transform.position;
            }
        }
    }

}