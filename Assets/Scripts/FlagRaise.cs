using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagRaise : MonoBehaviour {

    bool raised;
    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        raised = false;
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		while (raised && transform.position.y <= 1.15)
        {
            rb.velocity = new Vector3(0, Time.deltaTime, 0);
        }
	}

    void OnTriggerEnter2D(Collider2D c)
    {
        if (!raised)
            raised = true;
    }
}
