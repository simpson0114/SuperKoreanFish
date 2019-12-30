using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour {

    private Animator anime;

	// Use this for initialization
	void Start () {
        anime = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void attacked()
    {
        transform.localScale = new Vector3(2.351063f, 0.2552262f, 2.040448f);
        anime.SetBool("dead", true);
    } 
}
