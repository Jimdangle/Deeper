using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideScript : MonoBehaviour
{
    [SerializeField] Vector3 Axis;
    [SerializeField] float Speed;
    [SerializeField] float maxDistance;
    

    float theta;
    Vector3 spawnPos;
    void Start()
    {
        theta = 0;
        spawnPos = transform.position;
    }

    
    void Update()
    {
        theta += 0.01f * Speed;
        Vector3 newPos = Mathf.Sin(theta) * Axis * maxDistance;
        transform.position = spawnPos + newPos;
    }
}
