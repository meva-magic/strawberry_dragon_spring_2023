using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tail : MonoBehaviour
{
    public int length;
    public int newChains;

    public LineRenderer lineRend;

    public Transform targetDir;
    public float targetDist;
    public float smoothSpeed;
    public float trailSpeed;

    public float wiggleSpeed;
    public float wiggleMagnitude;
    public Transform wiggleDir;

    public Transform tailEnd;
    
    public Vector3[] segmentPoses;
    private Vector3[] segmentV;


    private void Start()
    {
        lineRend.positionCount = length;
        segmentPoses = new Vector3[length];
        segmentV = new Vector3[length];
    }

    public void AddLength()
    {
        length += newChains;
        lineRend.positionCount = length;
        segmentPoses = new Vector3[length];
        segmentV = new Vector3[length];
        
    }

    private void Update()
    {
        wiggleDir.localRotation = Quaternion.Euler(0, 0, Mathf.Sin(Time.time * wiggleSpeed) * wiggleMagnitude);
        
        segmentPoses[0] = targetDir.position;

        for (int i = 1; i < segmentPoses.Length; i++)
        {
            segmentPoses[i] = Vector3.SmoothDamp(segmentPoses[i], segmentPoses[i - 1] + targetDir.right * targetDist, ref segmentV[i], smoothSpeed + i / trailSpeed);
        }

        lineRend.SetPositions(segmentPoses);

        tailEnd.position = segmentPoses[segmentPoses.Length - 1];
    }

}
