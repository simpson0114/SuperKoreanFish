﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Initializer : MonoBehaviour {

    private 

	// Use this for initialization
	void Start () {
        if (!File.Exists(Application.persistentDataPath + "/gavesave.save"))
        {
            Save save = new Save();
            save.progress = 0;
            for (int i = 0; i < 4; i++)
                save.item[i] = 0;

            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
            bf.Serialize(file, save);
            file.Close();

            Debug.Log("data created");
        }
        else
        {
            Debug.Log("data exist");
        }
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(GameObject.Find("fade").GetComponent<FadeEffect>().FadeAndLoadScene(FadeEffect.FadeDirection.In, "menu"));
            Debug.Log("press");
        }
        
    }
}
