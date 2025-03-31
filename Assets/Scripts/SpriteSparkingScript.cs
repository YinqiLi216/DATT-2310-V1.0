using System;
using UnityEngine;

public class SpriteSparkingScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Boolean randomColor;
    private SpriteRenderer renderer;
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float r = UnityEngine.Random.Range(0.0f, 1.0f);
        float r1 = UnityEngine.Random.Range(0.0f, 1.0f);
        float r2 = UnityEngine.Random.Range(0.0f, 1.0f);
        float r3 = UnityEngine.Random.Range(0.0f, 1.0f);
        Color color = randomColor ? new Color(r1, r2, r3, r) : new Color(r, r, r, r);
        renderer.color = color;
    }
}
