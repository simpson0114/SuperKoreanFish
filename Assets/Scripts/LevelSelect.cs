using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour, IPointerClickHandler {

    public string SceneName;

    public void OnPointerClick(PointerEventData e)
    {
        if (SceneName == "quit")
            Application.Quit();
        else
            SceneManager.LoadScene(SceneName);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
