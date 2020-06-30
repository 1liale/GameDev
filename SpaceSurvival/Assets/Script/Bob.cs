﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bob : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform t;
    public float amplitude;
    public float time;
    private float ox;
    private float oy;
    private float oz;
    private float r = 0;
    private float i;
    void Start()
    {
        ox=t.position.x;
        oy=t.position.y;
        oz=t.position.z;
        i = 2F/(time/0.02F);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        //Debug.Log(r);
        t.SetPositionAndRotation(new Vector3(ox,oy+amplitude*Mathf.Sin(r),oz), t.rotation);
        r=(r+i)%(2*Mathf.PI);
    }
}