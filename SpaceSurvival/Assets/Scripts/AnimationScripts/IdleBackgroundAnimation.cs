using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBackgroundAnimation : MonoBehaviour
{
    public Transform t;
    private float br;
    private float rr;
    public float BobAmplitude; // by World coordinates
    public float RotationAmplitude; //in degrees
    public float BobTime; //Seconds
    public float RotationTime; //Seconds
    private float bx;
    private float by;
    private float bz;
    private float rz;
    private float rotationI;
    private float bobI;
    // Start is called before the first frame update
    void Start()
    {
        bx=t.position.x;
        by=t.position.y;
        bz=t.position.z;
        rotationI = 2F/(RotationTime/0.02F);
        bobI = 2F/(BobTime/0.02F);
        rz = t.eulerAngles.z;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        t.SetPositionAndRotation(new Vector3(bx,by+BobAmplitude*Mathf.Sin(br), bz), t.rotation);
        Quaternion q = Quaternion.Euler(t.eulerAngles.x, t.eulerAngles.y, Mathf.Sin(rr)*RotationAmplitude+rz);
        //Debug.Log(t.rotation);
        t.SetPositionAndRotation(t.position,q);
        br=(br+bobI)%(2*Mathf.PI);
        rr=(rr+rotationI)%(2*Mathf.PI);
    }
}
