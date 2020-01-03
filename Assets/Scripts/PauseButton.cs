using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour, IPointerClickHandler {

    public GameObject pause;
    public AudioClip soundEffect;

    private bool freeze;

    public void setFreeze(bool ipt)
    {
        freeze = ipt;
    }

    public void OnPointerClick(PointerEventData e)
    {
        if (freeze)
            return;

        GameObject.Find("Audio Source").GetComponent<AudioSource>().PlayOneShot(soundEffect);

        pause.SetActive(!pause.activeSelf);
        if (pause.activeSelf)
        {
            Time.timeScale = 0;
            GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/Buttons/play");
        }
        else
        {
            Time.timeScale = 1;
            GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/Buttons/pause");
        }
    }

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}
};
