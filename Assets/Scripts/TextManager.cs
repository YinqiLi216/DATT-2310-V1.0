using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using static UnityEngine.Rendering.DebugUI;

public class TextPresentor : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TextMeshProUGUI textMeshPro;
    public string[] lines;
    public float delay;
    private float autoDialogueTimer;
    private int index;
    private Boolean started, hideSelf;
    void Start()
    {
        textMeshPro.text = string.Empty;
        started = false;
        HidePanel(false);
    }

    // Update is called once per frame
    void Update()
    {
            if (!IsHidden() && !started)
            {
                StartDialogue();
                started = true;
                autoDialogueTimer = 5;
            }
            if (Input.GetKeyUp(KeyCode.E) || autoDialogueTimer <= 0)
            {
                if (textMeshPro.text == lines[index])
                {
                    NextLine();
                    autoDialogueTimer = 5;
                }
                else
                {
                    StopAllCoroutines();
                    textMeshPro.text = lines[index];
                }
            }
        autoDialogueTimer -= Time.deltaTime;
    }

    void StartDialogue(){
        index = 0;
        StartCoroutine(TypeLine()); 
    }

    IEnumerator TypeLine() {
        foreach (char c in lines[index].ToCharArray()) {
            textMeshPro.text += c;
            yield return new WaitForSeconds(delay);
        }
    }

    void NextLine() {
        textMeshPro.text = String.Empty;
        if (index < lines.Length - 1) {
            index++;
            StartCoroutine (TypeLine());
        }
        else
        {
            HidePanel(true);
            started = false;
            Timer.timeFlowing = true;
        }
    }

    public void HidePanel(Boolean hide) {
        hideSelf = hide;

        if (!hide)
        {
            transform.localScale = Vector3.one;
        }
        else
        {
            transform.localScale = Vector3.zero;
        }

    }
    public Boolean IsHidden() {
        return hideSelf;
    }
}
