using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
<summary>Class <c>IdleBackgroundAnimation</c> animates a GameObject to periodically bob vertically and rotate</summary>
*/
public class IdleBackgroundAnimation : MonoBehaviour
{
    ///<value>Transform component of the GameObject to animate</value>
    public Transform t;
    //Radians of Bob
    private float br;
    //Radians of rotation
    private float rr;
    ///How far in one vertical direction the object will move. <example><i>E.g. 0.05 moves it up 0.05 world units up, then 0.05 units down.</example></i>
    public float BobAmplitude; 
    ///The total amount of degrees the GameObject will rotate 
    public float RotationAmplitude;
    ///Time (Seconds) it takes to complete one bob cycle (E.g. move up, down and return to starting position).
    public float BobTime; 
    ///Time (Seconds) it takes to complete one rotation cycle.
    public float RotationTime; 
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
        //Set's Transform position
        t.SetPositionAndRotation(new Vector3(bx,by+BobAmplitude*Mathf.Sin(br), bz), t.rotation);
        //Converts euler coordinates to quaternion
        Quaternion q = Quaternion.Euler(t.eulerAngles.x, t.eulerAngles.y, Mathf.Sin(rr)*RotationAmplitude+rz);
        //Updates Transform rotation
        t.SetPositionAndRotation(t.position,q);

        //Changes the Radians for Bob and Rotation
        br=(br+bobI)%(2*Mathf.PI);
        rr=(rr+rotationI)%(2*Mathf.PI);
    }
}
