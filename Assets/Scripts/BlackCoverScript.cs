using System;
using UnityEngine;
using UnityEngine.UI;

public class BlackCoverScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Boolean turnAlpha;
    public Image image;
    public float duration;
    private float alpha, timer;


    // Update is called once per frame
    void Update()
    {

        if (turnAlpha)
        {
            timer += Time.deltaTime / duration;
            timer = timer >= 1 ? 1 : timer;
        }
        else {
            timer -= Time.deltaTime / duration;
            timer = timer <= 0 ? 0 : timer;
        }
        alpha = 1 - timer;
        image.color = new Color(0, 0, 0, alpha);
    }
}
