using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {

    public Transform player;
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = player.localPosition;
        pos.y += 1.13f;
        pos.z = -10;
        if (pos.y < 0)
            pos.y = 0;
        transform.localPosition = pos;

    }
}
