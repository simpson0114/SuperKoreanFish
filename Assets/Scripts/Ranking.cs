using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Rank
{
    string[] rank = { "F", "A", "B", "S" };
    string[] comment = { "韓黑", "韓粉", "狂熱韓粉", "鋼鐵韓粉" };
}

public class Ranking : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/gavesave.save", FileMode.Open);
        Save save = (Save)bf.Deserialize(file);
        file.Close();

        int cnt = 0;
        for (int i = 0; i < 4; i ++)
        {
            cnt += save.item[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
