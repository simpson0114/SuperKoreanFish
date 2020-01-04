using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    private Rigidbody2D rb;
    private Animator anime;
    private bool isGrounded;
    private bool freeze;

    [Header("Audio Setting")]
    public AudioSource audioSource;
    public AudioClip jumpEffect;

    private float stayTime;
    private AudioClip hit, attack;

    private int item;

	// Use this for initialization
	void Start () {
        isGrounded = false;
        freeze = false;
        stayTime = 0;
        rb = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
        hit = Resources.Load("Audios/sounds/death") as AudioClip;
        attack = Resources.Load("Audios/sounds/stomp") as AudioClip;

        item = 0;
	}

    public void setFreeze(bool ipt)
    {
        freeze = ipt;
    }

    public int GetItem()
    {
        return item;
    }
	
	// Update is called once per frame
	void Update () {
        anime.SetBool("isMove", false);

        if (freeze)
            return;

        if (Input.GetKey(KeyCode.D))
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * Time.deltaTime * 200, rb.velocity.y);
            anime.SetBool("isMove", true);
        }
        else if(Input.GetKey(KeyCode.A))
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * Time.deltaTime * 200, rb.velocity.y);
            anime.SetBool("isMove", true);
        }

        if (Input.GetKey(KeyCode.W) && isGrounded && Mathf.RoundToInt(rb.velocity.y) == 0)
        {
            isGrounded = false;
            rb.velocity += new Vector2(0, 5);
            anime.SetBool("isJump", true);
            audioSource.PlayOneShot(jumpEffect);
        }
    }
    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.collider.tag == "Ground")
        {
            isGrounded = true;
            anime.SetBool("isJump", false);
        }
        else if (c.collider.tag == "Enemy")
        {
            if (rb.velocity.y < 0 && !isGrounded)
            {
                isGrounded = true;
                anime.SetBool("isJump", false);
                audioSource.PlayOneShot(attack);
                c.collider.gameObject.GetComponent<EnemyControl>().attacked();
            }
            else if (!c.collider.gameObject.GetComponent<EnemyControl>().isDead())
            {
                attacked();
            }
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

    void OnCollisionStay2D(Collision2D c)
    {
        if (c.collider.tag == "Ground" && !isGrounded)
        {
            stayTime += Time.deltaTime;
            if (stayTime >= 0.3)
            {
                isGrounded = true;
                anime.SetBool("isJump", false);
                stayTime = 0;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag == "Item")
            item++;
    }

    public void attacked()
    { 
        setFreeze(true);
        GameObject.Find("pause").GetComponent<PauseButton>().setFreeze(true);
        GameObject.Find("Enemy").GetComponent<EnemyControl>().setFreeze(true);
        GameObject.Find("DeadDetect").GetComponent<DeadDetect>().GameOver(hit);
    }
}
