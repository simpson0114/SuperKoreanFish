﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour, IPointerClickHandler {

    [Header("Transition Effect")]
    public FadeEffect effect;

    [Header("Settings")]
    public string SceneName;
    public AudioClip soundEffect;

    private AudioSource audio;

    public void OnPointerClick(PointerEventData e)
    {
        audio.PlayOneShot(soundEffect);

        if (SceneName == "quit")
            Application.Quit();
        else
        {
            Time.timeScale = 1;
            StartCoroutine(effect.FadeAndLoadScene(FadeEffect.FadeDirection.In, SceneName));
        }
    }

	// Use this for initialization
	void Start () {
        effect = GameObject.Find("fade").GetComponent<FadeEffect>();
        audio = GameObject.Find("Audio Source").GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
