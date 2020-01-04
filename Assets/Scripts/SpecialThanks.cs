﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialThanks : MonoBehaviour
{
    public float stepSize;
    public Vector3 target;

    private FadeEffect effect;

    // Start is called before the first frame update
    void Start()
    {
        once = false;
        buffer = 0;
        effect = GameObject.Find("fade").GetComponent<FadeEffect>();
    }

    // Update is called once per frame
    void Update()
    {
        if (buffer <= 3 && !once)
        {
            buffer += Time.deltaTime;
            return;
        }

        if (transform.localPosition.y <= target.y)
        }
            {
                buffer += Time.deltaTime;
                Debug.Log(buffer);
            }
            else
                StartCoroutine(effect.FadeAndLoadScene(FadeEffect.FadeDirection.In, "menu"));
    }
}