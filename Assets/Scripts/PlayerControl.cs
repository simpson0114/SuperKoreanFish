using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    private Rigidbody2D rb;
    private Animator anime;
    private bool isGrounded;

	// Use this for initialization
	void Start () {
        isGrounded = false;

        rb = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        anime.SetFloat("speed", 0);
        Vector2 v = rb.velocity;
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * Time.deltaTime * 400, v.y);
            anime.SetFloat("speed", rb.velocity.x);
        }
        else if(Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * Time.deltaTime * 400, v.y);
            anime.SetFloat("speed", Mathf.Abs(rb.velocity.x));
        }

        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            isGrounded = false;
            rb.velocity += new Vector2(0, 5);
            anime.SetBool("isJump", true);
        }

        
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        Debug.Log(c.collider.tag);
        if (c.collider.tag == "Ground")
        {
            isGrounded = true;
            anime.SetBool("isJump", false);
        }
    }
}
