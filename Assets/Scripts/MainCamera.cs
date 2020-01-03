using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {

    public Transform player;
    public float upperbound;
    public float lowerbound;

    // Use this for initialization
    void Start () {
        upperbound = 2.0f;
        lowerbound = 0.1f;

        transform.localPosition = new Vector3(player.position.x, Mathf.Max(player.position.y, lowerbound), -10);
    }
	
	// Update is called once per frame
	void Update () {
        if (player.position.y - transform.localPosition.y >= 1.25 && transform.localPosition.y <= upperbound)
        {
            transform.localPosition += new Vector3(0, 3f * Time.deltaTime, 0);
        }
        else if (transform.localPosition.y - player.position.y >= 1.25 && transform.localPosition.y >= lowerbound)
        {
            transform.localPosition += new Vector3(0, -3f * Time.deltaTime, 0);
        }
        
        if (player.position.x - transform.localPosition.x >= 1.25)
        {
            transform.localPosition += new Vector3(3f * Time.deltaTime, 0, 0);
        }
        else if (transform.localPosition.x - player.position.x >= 1.25)
        {
            transform.localPosition -= new Vector3(3f * Time.deltaTime, 0, 0);
        }

        // transform.localPosition = new Vector3(player.position.x, Mathf.Max(player.position.y + 1.1f, lowerbound), -10);

    }

    IEnumerator LerpFromTo(Vector3 pos1, Vector3 pos2, float duration)
    {
        for (float t = 0f; t < duration; t += Time.deltaTime)
        {
            transform.localPosition = Vector3.Lerp(pos1, pos2, t / duration);
            yield return 0;
        }
        transform.localPosition = pos2;
    }
}
