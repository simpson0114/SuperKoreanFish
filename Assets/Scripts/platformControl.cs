using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformControl : MonoBehaviour {

    [Header("Boundary Setting")]
    public float left;
    public float right;

    [Header("Move Setting")]
    public float stepSize;
    public float duration;

    Vector3 des;

	// Use this for initialization
	void Start () {
        des = transform.position;
        des.x = right;
	}
	
	// Update is called once per frame
	void Update () {
        /*
        transform.position = Vector3.MoveTowards(transform.position, des, Time.deltaTime * stepSize);
        if (transform.position.x >= right)
            des.x = left;
        else if (transform.position.x <= left)
            des.x = right;
            */
        StartCoroutine(LerpTo(transform.position, des, duration));
        des.x = left;
        StartCoroutine(LerpTo(transform.position, des, duration));
        des.x = right;
	}

    IEnumerator LerpTo(Vector3 pos1, Vector3 pos2, float duration)
    {
        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            transform.position = Vector3.Lerp(pos1, pos2, t / duration);
            yield return 0;
        }
        transform.position = pos2;

        if (transform.position.x >= right)
            des.x = left;
        else if (transform.position.x <= left)
            des.x = right;
    }
}
