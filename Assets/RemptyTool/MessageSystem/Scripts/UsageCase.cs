using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RemptyTool.ES_MessageSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(ES_MessageSystem))]
public class UsageCase : MonoBehaviour
{
    private ES_MessageSystem msgSys;
    public Text uiText;
    public TextAsset textAsset;
    public bool triggerd;
    public GameObject messagePanel;

    private List<string> textList = new List<string>();
    private int textIndex = 0;

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag == "Player")
        {
            Debug.Log("enter");
            msgSys.Next();
            triggerd = true;
        }
    }

    void Start()
    {
        msgSys = this.GetComponent<ES_MessageSystem>();
        if (uiText.text == null)
        {
            Debug.LogError("UIText Component not assign.");
        }
        else
            ReadTextDataFromAsset(textAsset);

        triggerd = false;
        messagePanel.SetActive(false);

        //add special chars and functions in other component.
        msgSys.AddSpecialCharToFuncMap("UsageCase", CustomizedFunction);
        msgSys.AddSpecialCharToFuncMap("hide", hide);
        msgSys.AddSpecialCharToFuncMap("show", show);
        msgSys.AddSpecialCharToFuncMap("rst", reset);
        msgSys.AddSpecialCharToFuncMap("tmp", tmp);
        msgSys.AddSpecialCharToFuncMap("slct", select);
    }

    private void CustomizedFunction()
    {
        Debug.Log("Hi! This is called by CustomizedFunction!");
    }

    void tmp()
    {

        Debug.Log("test");
    }

    void reset()
    {
        uiText.text = "";
        textList.Clear();
        textIndex = 0;
        Start();
    }


    void hide()
    {
        triggerd = false;
        messagePanel.SetActive(false);
        GameObject.Find("Player").GetComponent<PlayerControl>().setFreeze(false);
        if (tag == "Item")
            Destroy(gameObject);
    }

    void show()
    {
        triggerd = true;
        messagePanel.SetActive(true);
        GameObject.Find("Player").GetComponent<PlayerControl>().setFreeze(true);    
        GameObject.Find("Player").GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    void select()
    {
        SceneManager.LoadScene("select");
    }

    private void ReadTextDataFromAsset(TextAsset _textAsset)
    {
        textList.Clear();
        textIndex = 0;
        var lineTextData = _textAsset.text.Split('\n');
        foreach (string line in lineTextData)
        {
            textList.Add(line);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && triggerd)
        {
            //You can sending the messages from strings or text-based files.
            if (msgSys.IsCompleted)
            {
                msgSys.SetText("Send the messages![lr] HelloWorld![w]");
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && triggerd)
        {
            //Continue the messages, stoping by [w] or [lr] keywords.
            msgSys.Next();
        }

        //If the message is complete, stop updating text.
        if (msgSys.IsCompleted == false)
        {
            uiText.text = msgSys.text;
        }

        //Auto update from textList.
        if (msgSys.IsCompleted == true && textIndex < textList.Count)
        {
            msgSys.SetText(textList[textIndex]);
            textIndex++;
        }
    }
}
