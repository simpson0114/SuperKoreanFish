using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Initializer : MonoBehaviour {

    public float fadeSpeed;

    private Text text;

    private float alpha;
    private float oper;

    private AudioSource source;
    private AudioClip clip;

	// Use this for initialization
	void Start () {
        text = GameObject.Find("Text").GetComponent<Text>();

        alpha = 0;
        oper = 1.0f;

        source = GameObject.Find("Audio Source").GetComponent<AudioSource>();
        clip = Resources.Load("Audios/sounds/coin") as AudioClip;

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
            source.PlayOneShot(clip);
            StartCoroutine(GameObject.Find("fade").GetComponent<FadeEffect>().FadeAndLoadScene(FadeEffect.FadeDirection.In, "menu"));
        }
        
        text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);

        alpha += oper * Time.deltaTime;
        if (alpha >= 1)
            oper = -1;
        else if (alpha <= 0)
            oper = 1;
        
    }
}
