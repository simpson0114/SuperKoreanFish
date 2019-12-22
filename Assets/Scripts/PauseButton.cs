using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseButton : MonoBehaviour, IPointerClickHandler {

    public GameObject pause;

    public void OnPointerClick(PointerEventData e)
    {
        pause.SetActive(!pause.activeSelf);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
};
