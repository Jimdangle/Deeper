using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strobe : MonoBehaviour
{
    public float StrobeTime;
    public float intensityMax;
    public Color color;

    Light liggy;
    float change;
    void Start()
    {
        liggy = GetComponent<Light>();
        liggy.color = color;

        change = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (StrobeTime == 0)
        {
            liggy.intensity = intensityMax;
        }
        else
        {
            float calcInt = intensityMax * Mathf.Cos(change / StrobeTime); ;
            if (calcInt > 0) { liggy.intensity = calcInt; }
            else { liggy.intensity = -1 * calcInt; }
        }

        change += 0.1f;
    }
}
