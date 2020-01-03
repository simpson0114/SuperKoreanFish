using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class DataReader : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject[] level = { GameObject.Find("Kaohsiung"), GameObject.Find("Tainan"), GameObject.Find("Taichung"), GameObject.Find("Taipei") };

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
        Save save = (Save)bf.Deserialize(file);
        file.Close();

        Debug.Log("progress " + save.progress);
        Debug.Log("item count");
        for (int i = 0; i < 4; i ++)
        {
            Debug.Log(save.item[i]);
        }

        for (int i = 0; i < 4; i ++)
        {
            if (i <= save.progress)
                level[i].SetActive(true);
            else
                level[i].SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
