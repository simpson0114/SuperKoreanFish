using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionBlock : MonoBehaviour {

    private Vector3 pos;
    private Animator anime;
    private Rigidbody2D rb;

    bool used;

	// Use this for initialization
	void Start () {
        anime = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        pos = transform.position;

        used = false;
    }
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < pos.y && used)
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        if (!used && transform.position.y < pos.y)
        {
            rb.velocity = Vector3.zero;
            transform.position = pos;
        }
	}

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.collider.tag == "Player" && !used)
        {
            rb.velocity = new Vector3(0, 0.5f, 0);
            anime.SetBool("used", true);

            used = true;
        }
    }
}
