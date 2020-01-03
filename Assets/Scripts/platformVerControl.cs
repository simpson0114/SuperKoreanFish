using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformVerControl : MonoBehaviour
{

    [Header("Boundary Setting")]
    public float up;
    public float down;

    [Header("Move Setting")]
    public float stepSize;
    public float duration;

    Vector3 des;

    // Use this for initialization
    void Start()
    {
        des = transform.position;
        des.y = up;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, des, Time.deltaTime * stepSize);
        if (transform.position.y >= up)
            des.y = down;
        else if (transform.position.y <= down)
            des.y = up;
    }
}
