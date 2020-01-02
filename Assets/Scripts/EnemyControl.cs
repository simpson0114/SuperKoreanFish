using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour {

    private Animator anime;
    private bool dead;
    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        dead = false;
        anime = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (dead)
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, new Vector3(2.351063f, 0.2552262f, 2.040448f), Time.deltaTime * 10);
        }
	}

    public void attacked()
    {
        //transform.localScale = new Vector3(2.351063f, 0.2552262f, 2.040448f);
        dead = true;
        anime.SetBool("dead", true);
        rb.velocity += new Vector2(0, -3);
    } 
}
