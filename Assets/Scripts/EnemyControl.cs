using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour {

    private Animator anime;
    private bool dead;
    private Rigidbody2D rb;
    private float wait;
    private float direction;
    private bool freeze;

	// Use this for initialization
	void Start () {
        dead = false;
        freeze = false;
        wait = 0;
        direction = 1f;
        anime = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (freeze)
            return;

		if (dead)
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, new Vector3(2.351063f, 0.2552262f, 2.040448f), Time.deltaTime * 10);
        }
        else if (wait <= 0)
        {
            int choice = Random.Range(0, 5);
            Debug.Log("choice " + choice);
            if (choice == 0)
            {
                wait = Random.Range(1, 1.5f);
            }
            else
            {
                wait = Random.Range(1.5f, 2f);
            }
        }
        else if (wait > 0)
        {
            transform.position += new Vector3(Time.deltaTime * direction, 0, 0);
            wait -= Time.deltaTime;
        }
        Debug.Log("wait " + wait);
	}

    public void attacked()
    {
        //transform.localScale = new Vector3(2.351063f, 0.2552262f, 2.040448f);
        dead = true;
        anime.SetBool("dead", true);
        rb.velocity += new Vector2(0, -3);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "boundary")
            direction = -direction;
    }

    public void setFreeze(bool ipt)
    {
        freeze = ipt;
    }
}
