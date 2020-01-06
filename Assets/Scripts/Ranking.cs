using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;

[SerializeField]
public class Rank
{
    static public string[] rank = { "F", "B", "A", "S" };
    static public string[] comment = { "韓黑", "韓粉", "狂熱韓粉", "鋼鐵韓粉" };
    public AudioClip[] audios = new AudioClip[4];
}

public class Ranking : MonoBehaviour
{

    public AudioClip S;
    public AudioClip A;
    public AudioClip B;
    public AudioClip F;

    private Rank rank;

    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
        Save save = (Save)bf.Deserialize(file);
        rank = new Rank();
        file.Close();

        // audio settings
        rank.audios[0] = F;
        rank.audios[1] = B;
        rank.audios[2] = A;
        rank.audios[3] = S;

        source = GameObject.Find("Audio Source").GetComponent<AudioSource>();

        int cnt = 0;
        for (int i = 0; i < 4; i ++)
        {
            // counting result;
            cnt += save.item[i];
        }

        GameObject.Find("rank").GetComponent<Text>().text = Rank.rank[cnt / 4];
        GameObject.Find("comment").GetComponent<Text>().text = "你是" + Rank.comment[cnt / 4];
        source.PlayOneShot(rank.audios[cnt / 4]);
        for (int i = 0; i < 4; i++)
        {
            if (i == cnt / 4)
                GameObject.Find("image").transform.GetChild(i).gameObject.SetActive(true);
            else
                GameObject.Find("image").transform.GetChild(i).gameObject.SetActive(false);

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
