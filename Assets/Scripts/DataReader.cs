using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class DataReader : MonoBehaviour {

	// Use this for initialization
	void Start () {
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
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
