﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour {

    public Rigidbody2D player;

    public float rate;
    private Rigidbody2D rb;


	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        float velocity = player.velocity.x * rate;
        rb.velocity = new Vector3(velocity, 0, 0);
	}
}