using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    private Rigidbody2D rb;
    private Animator anime;
    private bool isGrounded;

    [Header("Audio Setting")]
    public AudioSource audioSource;
    public AudioClip jumpEffect;
    public AudioClip fallEffect;

    bool playOnce;

	// Use this for initialization
	void Start () {
        isGrounded = false;
        rb = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();

        playOnce = true;
	}
	
	// Update is called once per frame
	void Update () {
        anime.SetBool("isMove", false);
        Vector2 v = rb.velocity;
        if (Input.GetKey(KeyCode.D))
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * Time.deltaTime * 200, v.y);
            anime.SetBool("isMove", true);
        }
        else if(Input.GetKey(KeyCode.A))
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * Time.deltaTime * 200, v.y);
            anime.SetBool("isMove", true);
        }

        if (Input.GetKey(KeyCode.W) && isGrounded)
        {
            isGrounded = false;
            rb.velocity += new Vector2(0, 5);
            anime.SetBool("isJump", true);
            audioSource.PlayOneShot(jumpEffect);
        }

        if (transform.position.y <= -3.5 && playOnce)
        {
            audioSource.PlayOneShot(fallEffect, 0.5f);
            playOnce = false;
        }
    }
    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.collider.tag == "Ground")
        {
            isGrounded = true;
            anime.SetBool("isJump", false);
        }
    }
    
    void OnCollisionExit2D(Collision2D c)
    {
        if (c.collider.tag == "Ground")
        {
            isGrounded = false;
            anime.SetBool("isJump", true);
        }
    }
}
