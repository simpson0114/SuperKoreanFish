using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour {

    public Transform player;
    public GameObject pause;

    public float rate;
    private Rigidbody2D rb;
    private float prev;


	// Use this for initialization
	void Start () {
        prev = player.transform.position.x;
        pause.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        float curr = player.transform.position.x;
        transform.position += new Vector3(curr - prev, 0, 0) * rate;
        prev = curr;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause.SetActive(!pause.activeSelf);
            if (pause.activeSelf)
                Time.timeScale = 0;
            else
                Time.timeScale = 1;
        }
	}
}
