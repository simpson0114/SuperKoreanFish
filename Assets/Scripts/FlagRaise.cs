using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagRaise : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag == "Player")
            transform.Translate(Vector3.up * Time.deltaTime);
    }
}
