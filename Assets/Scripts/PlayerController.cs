using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction.Input;


public class PlayerController : MonoBehaviour
{

    public float movementSpeed = 0.5f;

    public AudioSource backgroundMusicSource;
    public AudioSource introAudio;

    OVRCameraRig[] CameraRig;
    // Start is called before the first frame update
    void Start()
    {
        // CameraRig = gameObject.GetComponentsInChildren<OVRCameraRig>();
       
        // Play BG music wth a delay
        backgroundMusicSource.Play(3);
        // Play IntroAudio after a delay
        Invoke("PlayIntroAudio", 3f);
    }

    // Method to play the introAudio
    void PlayIntroAudio()
    {
        introAudio.Play();
    }

    // Update is called once per frame
    void Update()
    {


/*
  
        Transform headTransform = CameraRig[0].centerEyeAnchor; // Assuming OVR Rig

        // Get forward direction and thumbstick input
        Vector3 forwardDirection = headTransform.rotation * headTransform.forward;
        forwardDirection.y = 0;
        Vector2 thumbstick = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        if(thumbstick.y > 0)
        {

        
        // Apply movement constraints
        Vector3 projection = Vector3.Project(thumbstick, forwardDirection);
        float angle = Vector3.Angle(projection, forwardDirection);
        if (angle < 90f || projection.magnitude > movementSpeed)
        {
            projection = forwardDirection * movementSpeed;
        }

        // Apply movement using Transform
        transform.Translate(projection * Time.deltaTime);
        }
        

        */


        /* Vector3 moveDirection =  gameObject.transform.forward;
             Vector2 axis = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);

             moveDirection += new Vector3(axis.x, 0, axis.y) * 2;
             transform.position += moveDirection * Time.deltaTime;
             OVRInput.SetControllerVibration( 0.5f, 0.5f);
            // controller.

             if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.LTouch)==1)

             {
                 Debug.Log("Triggered");
                // OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.LTouch);
                // OVRInput.SetControllerLocalizedVibration(OVRInput.HapticsLocation.Index, 0.5f,0.5f, OVRInput.Controller.LTouch);
             }


             //transform.Translate(new Vector3(axis.x, 0, axis.y) * 2 * Time.deltaTime);

             //transform.RotateAround(this.transform.position, Vector3.up, 20 * Time.deltaTime);
        */
    }
}
