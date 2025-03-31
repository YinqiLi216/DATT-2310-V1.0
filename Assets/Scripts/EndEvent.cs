using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndEvent : MonoBehaviour
{
    public string sceneName;
    private Boolean triggered;
    private GameObject blackCover;

    void Start()
    {
        triggered = true;
        if (GameObject.Find("Black") != null)
        {
            blackCover = GameObject.Find("Black");
        }
    }
    void Update()
    {
        if (Timer.globalRemainTime <= 0 && triggered)
        {
            blackCover.GetComponent<BlackCoverScript>().turnAlpha = false;
            Invoke("SwitchScene", 3f);
            triggered = false;
        }
    }
    public void SwitchScene()
    {
        SceneManager.LoadScene(sceneName);
    }

}

