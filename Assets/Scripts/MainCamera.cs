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
        transform.localPosition = new Vector3(player.position.x, 0.08f, -10);

    }
}
