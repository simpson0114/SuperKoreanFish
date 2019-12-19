using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionBlock : MonoBehaviour {

    private Vector3 pos;
    private Animator anime;
    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        anime = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        pos = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y <= pos.y)
        {
            rb.velocity = new Vector3(0, 0, 0);
            transform.position = pos;
        }
	}

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.collider.tag == "Player")
        {
            rb.velocity = new Vector3(0, 0.5f, 0);
            anime.SetBool("used", true);
        }
    }
}
