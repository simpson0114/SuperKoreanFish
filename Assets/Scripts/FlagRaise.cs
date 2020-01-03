using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public class FlagRaise : MonoBehaviour {

    public float stepSize;
    bool raised;
    bool once;
    public Vector3 target = new Vector3(67.1476f, 1.15f, 0);
    public bool final;

    FadeEffect effect;

    // Use this for initialization
    void Start() {
        raised = false;
        once = false;

        effect = GameObject.Find("fade").GetComponent<FadeEffect>();
    }

    // Update is called once per frame
    void Update() {
        if (raised && transform.position.y <= 1.15)
        {
            if (transform.position.y >= 1.14)
            {
                once = true;
            }
            transform.position = Vector3.MoveTowards(transform.position, target, stepSize * Time.deltaTime);
           
        }

        if (once)
        {
            once = false;
            if (!final)
                StartCoroutine(effect.Fade(FadeEffect.FadeDirection.In));
            else
                StartCoroutine(effect.FadeAndLoadScene(FadeEffect.FadeDirection.In, "result"));
        }
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag == "Player")
        {
            raised = true;
            SaveGame();
        }
    }

    void SaveGame()
    {

        int index = 0;
        if (SceneManager.GetActiveScene().name == "game")
            index = 0;
        else if (SceneManager.GetActiveScene().name == "Tainan")
            index = 1;
        else if (SceneManager.GetActiveScene().name == "Taichung")
            index = 2;
        else if (SceneManager.GetActiveScene().name == "TPE")
            index = 3;

        if (File.Exists(Application.persistentDataPath + "/gamesave.save"))
        {
            // load save file in
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
            Save save = (Save)bf.Deserialize(file);
            file.Close();

            // save
            save.progress = index;
            save.item[index] = GameObject.Find("Player").GetComponent<PlayerControl>().GetItem();

            FileStream output = File.Create(Application.persistentDataPath + "/gamesave.save");
            bf.Serialize(output, save);
            output.Close();
            Debug.Log("game save index" + index + "+" + save.item[index]);
        }
        
    }
}
