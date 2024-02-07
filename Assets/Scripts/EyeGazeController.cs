using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeGazeController : MonoBehaviour
{
    public GameObject arrow;
    OVREyeGaze eyeGaze;

    void Start()
    {
        eyeGaze = GetComponent<OVREyeGaze>();
        Debug.Log("Eye Tracking is -" + eyeGaze.EyeTrackingEnabled);
        Debug.Log(OVRPlugin.eyeTrackingEnabled);
        Debug.Log(OVRPlugin.eyeTrackingSupported);
    }

    void Update()
    {
        if (eyeGaze == null)
        {
            Debug.Log("Eye Gaze Object is -" + eyeGaze.EyeTrackingEnabled);
        }

        if (eyeGaze.EyeTrackingEnabled)
        {
            arrow.transform.rotation = eyeGaze.transform.rotation;
        }
    }
}
