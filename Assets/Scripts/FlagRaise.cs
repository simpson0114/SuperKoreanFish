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

    [Header("Moving Setting")]
    public Vector3 target;

    [Header("Audio Clip")]
    public AudioClip soundEffect;

    FadeEffect effect;

    // Use this for initialization
    void Start() {
        raised = false;
        once = false;

        effect = GameObject.Find("fade").GetComponent<FadeEffect>();
    }

    // Update is called once per frame
    void Update() {
        if (raised && transform.localPosition.y <= target.y)
        {
            if (transform.localPosition.y >= target.y - 0.01)
            {
                once = true;
            }
            Debug.Log("moving");
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, target, stepSize * Time.deltaTime);
           
        }

        if (once)
        {
            once = false;            
            StartCoroutine(effect.Fade(FadeEffect.FadeDirection.In));
        }
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag == "Player")
        {
            raised = true;
            GameObject.Find("Audio Source").GetComponent<AudioSource>().Pause();
            GameObject.Find("Audio Source").GetComponent<AudioSource>().PlayOneShot(soundEffect);
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
        else if (SceneManager.GetActiveScene().name == "practice")
            index = -1;

        if (File.Exists(Application.persistentDataPath + "/gamesave.save"))
        {
            // load save file in
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
            Save save = (Save)bf.Deserialize(file);
            file.Close();

            // save
            if (index != -1)
            {
                save.progress = Mathf.Min(index + 1, 3);
                save.item[index] = GameObject.Find("Player").GetComponent<PlayerControl>().GetItem();

                FileStream output = File.Create(Application.persistentDataPath + "/gamesave.save");
                bf.Serialize(output, save);
                output.Close();
                Debug.Log("game save index" + index + "+" + save.item[index]);
            }
            else
            {
                Debug.Log("remain same");
            }
        }        
    }
}
