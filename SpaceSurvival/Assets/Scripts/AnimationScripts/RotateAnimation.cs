using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAnimation : MonoBehaviour
{
    public Transform t;
    private float r;
    private float i;
    public float Time;
    public float Amplitude;
    private float z;
    // Start is called before the first frame update
    void Start()
    {
        i = 2F/(Time/0.02F);
        z = t.eulerAngles.z;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Quaternion q = Quaternion.Euler(t.eulerAngles.x, t.eulerAngles.y, Mathf.Sin(r)*Amplitude+z);
        //Debug.Log(t.rotation);
        t.SetPositionAndRotation(t.position,q);
        r=(r+i)%(2*Mathf.PI);
    }
}
