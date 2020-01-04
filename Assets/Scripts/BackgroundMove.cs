using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour {

    public Transform player;
    public GameObject pause;

    public float rate;
    private Rigidbody2D rb;
    private float prev;
    private AudioSource source;
    private AudioClip clip;
    private bool freeze;


	// Use this for initialization
	void Start () {
        freeze = false;
        prev = player.transform.position.x;
        pause.SetActive(false);
        source = GameObject.Find("Audio Source").GetComponent<AudioSource>();
        clip = Resources.Load("Audios/sounds/coin") as AudioClip;
	}
	
	// Update is called once per frame
	void Update () {
        float curr = player.transform.position.x;
        transform.position += new Vector3(curr - prev, 0, 0) * rate;
        prev = curr;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (freeze)
                return;

            pause.SetActive(!pause.activeSelf);
            if (pause.activeSelf)
            {
                Time.timeScale = 0;
                source.Pause();
            }
            else
            {
                Time.timeScale = 1;
                source.UnPause();
            }
            source.PlayOneShot(clip);
        }
    }

    public void setFreeze(bool ipt)
    {
        freeze = ipt;
    }
}
