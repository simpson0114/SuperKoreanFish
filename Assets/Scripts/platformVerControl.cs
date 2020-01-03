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
        StartCoroutine(LerpTo(transform.position, des, duration));
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator LerpTo(Vector3 pos1, Vector3 pos2, float duration)
    {
        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            transform.position = Vector3.Lerp(pos1, pos2, t / duration);
            yield return 0;
        }
        transform.position = pos2;

        if (transform.position.y >= up)
        {
            des.y = down;
            StartCoroutine(LerpTo(transform.position, des, duration));
        }
        else if (transform.position.y <= down)
        {
            des.y = up;
            StartCoroutine(LerpTo(transform.position, des, duration));
        }

        
    }
}
