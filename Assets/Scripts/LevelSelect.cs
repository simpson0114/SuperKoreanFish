using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour, IPointerClickHandler {

    [Header("Transition Effect")]
    public FadeEffect effect;

    [Header("Settings")]
    public string SceneName;

    public void OnPointerClick(PointerEventData e)
    {
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
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
