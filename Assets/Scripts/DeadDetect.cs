using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeadDetect : MonoBehaviour {

    [Header("Audio Settings")]
    public AudioSource source;
    public AudioClip fallEffect;

    [Header("UI Settings")]
    public GameObject gamePausePanel;

    private PauseButton pause;

	// Use this for initialization
	void Start () {
        pause = GameObject.Find("pause").GetComponent<PauseButton>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag == "Player")
        {
            gamePausePanel.transform.GetChild(3).GetComponent<Text>().text = "game over";
            gamePausePanel.SetActive(true);
            source.PlayOneShot(fallEffect);
            pause.setFreeze(false);
            Time.timeScale = 0;
        }
        else
            Destroy(c.gameObject);
    }
}
