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

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag == "Player")
        {
            GameOver(fallEffect);
        }
        else
            Destroy(c.gameObject);
    }

    public void GameOver(AudioClip clip)
    {
        gamePausePanel.transform.GetChild(3).GetComponent<Text>().text = "game over";
        gamePausePanel.SetActive(true);
        source.Stop();
        source.PlayOneShot(clip);
        GameObject.Find("pause").GetComponent<PauseButton>().setFreeze(true);
        GameObject.Find("Background").GetComponent<BackgroundMove>().setFreeze(true);
        Time.timeScale = 0;
    }
}
