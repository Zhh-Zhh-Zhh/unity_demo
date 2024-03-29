﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipeline : MonoBehaviour
{
    public float min;
    public float max;
    public float speed;
    float t = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void Init()
    {
        float y = Random.Range(min, max);
        this.transform.localPosition = new Vector3(0, y, 0); 
    }

    // Update is called once per frame

    void Update()
    {
        this.transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
        t += Time.deltaTime;
        if (t > 6.9f)
        {
            t = 0;
            this.Init();
        }
    }
}
