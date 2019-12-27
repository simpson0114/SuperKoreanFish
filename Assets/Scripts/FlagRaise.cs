using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagRaise : MonoBehaviour {

    public float stepSize;
    bool raised;
    Vector3 target = new Vector3(67.1476f, 1.15f, 0);

    // Use this for initialization
    void Start() {
        raised = false;
    }

    // Update is called once per frame
    void Update() {
        if (raised && transform.position.y <= 1.15)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, stepSize * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag == "Player")
            raised = true;
    }
}
