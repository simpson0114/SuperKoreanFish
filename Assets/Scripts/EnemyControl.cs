using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour {

    private Animator anime;
    private bool dead;
    private Rigidbody2D rb;
    private float wait;
    private int direction;
    private bool freeze;
    private int choice;

	// Use this for initialization
	void Start () {
        dead = false;
        freeze = false;
        wait = 0;
        direction = 1;
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
            choice = Random.Range(0, 3);
            Debug.Log("choice " + choice);
            direction = Random.Range(-1, 1);

            if (choice == 0)
            {
                wait = Random.Range(2f, 3f);
                direction = 0;
            }
            else
            {
                wait = Random.Range(3.5f, 4f);
                direction = Random.Range(0, 1) * 2 - 1;
            }
        }
        else if (wait > 0)
        {
            transform.position += new Vector3(Time.deltaTime * direction, 0, 0);
            wait -= Time.deltaTime;
        }
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

    public bool isDead()
    {
        return dead;
    }
}
