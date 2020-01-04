using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class DataCreater : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Save save = new Save();
        save.progress = 3;
        for (int i = 0; i < 4; i++)
            save.item[i] = 3;

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/log.save");
        bf.Serialize(file, save);
        file.Close();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
