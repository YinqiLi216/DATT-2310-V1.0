using System;
using UnityEngine;

public class GlitchScirpt : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float posOffset, scaleOffset;
    public Boolean randomPos, randomScale;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float r = UnityEngine.Random.Range(-posOffset, posOffset);
        float r1 = UnityEngine.Random.Range(-posOffset, posOffset);
        float r2 = UnityEngine.Random.Range(1-scaleOffset, 1+scaleOffset);
        float r3 = UnityEngine.Random.Range(1-scaleOffset, 1 + scaleOffset);
        if (randomPos) { 
            transform.localPosition = new Vector2(r, r1);
        }
        if (randomScale)
        {
            transform.localScale = new Vector2(r2, r3);
        }
    }
}
