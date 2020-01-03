using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformControl : MonoBehaviour {

    [Header("Boundary Setting")]
    public float left;
    public float right;

    [Header("Move Setting")]
    public float stepSize;

    Vector3 des;

	// Use this for initialization
	void Start () {
        des = transform.position;
        des.x = right;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, des, Time.deltaTime * stepSize);
        if (transform.position.x >= right)
            des.x = left;
        else if (transform.position.x <= left)
            des.x = right;
	}
}
