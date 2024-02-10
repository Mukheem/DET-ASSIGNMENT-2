using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction.Input;



public class PlayerController : MonoBehaviour
{
    public float fadeSpeed = 1f;
    public float spawnDistance = 1.5f;
    public float acceleration = 0.05f;
    public AudioSource backgroundMusicSource;
    public GameObject canvasObject;
    public GameObject witch;
    OVRCameraRig[] CameraRig;
    Transform headTransform;
    public bool fadingOut = false;

    public UnityEngine.UI.RawImage image;
    // Start is called before the first frame update
    void Start()
    {
        CameraRig = gameObject.GetComponentsInChildren<OVRCameraRig>();
       
        headTransform = CameraRig[0].centerEyeAnchor;
        witch.SetActive(false);
        
    }

    private void FixedUpdate()
    {
        if (canvasObject.activeInHierarchy && (OVRInput.Get(OVRInput.RawButton.LIndexTrigger) && OVRInput.Get(OVRInput.RawButton.RIndexTrigger)))
        {
            canvasObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        // Make Menu follow the user vision
        canvasObject.transform.position = headTransform.position + new Vector3(headTransform.forward.x, 0, headTransform.forward.z).normalized * spawnDistance;
        canvasObject.transform.LookAt(new Vector3(headTransform.position.x, canvasObject.transform.position.y, headTransform.position.z));
        canvasObject.transform.forward *= -1;

        // Player's rotation
        var controllerAxis = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick, OVRInput.Controller.LTouch); //Take the input from Left thumbstick
        float fixedY = gameObject.transform.position.y; // Fixing the position of Y so that user doesnot fly(Y axis)
        /*Map the values of Controller with the player.
         * 
         * Player is in 3D space thus coordinates x,y and z. 
         * Controller has only 2 coordinates X and Y.
         * 
         * Note that when a player is seen in unity from top view, Player's Z axis is up, X axis is Right and Y axis is towards you.
         * In this case, if we have to see Controller's X and Y axes correspondence with Player's axes
         *  then Controller's X corresponds to Player's X, Controller's Y corresponds to Player's Z. 
         *  
         *  Thus the below vector3 mapped { new Vector3(controllerAxis.x, 0f, controllerAxis.y) }
         *  
         *  
         * */
        Vector3 movement = new Vector3(controllerAxis.x, 0f, controllerAxis.y) * Time.deltaTime * acceleration;
        gameObject.transform.Translate(movement, headTransform); // translating the player relative to HMD's direction. it could be local space or world space.
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, fixedY, gameObject.transform.position.z); //Trying to fix the Y axes to ground. This avoids movement of player when he looks up in the air.

        //Fades out Screen upon game completion
        if (fadingOut)
        {
            image.color = new Color(0, 0, 0, image.color.a + fadeSpeed * Time.deltaTime);
            if (image.color.a >= 1f)
            {
                fadingOut = false;
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Witches Place");
        Debug.Log(other.gameObject.name);
        if(other.CompareTag("Portal"))
        {
            witch.SetActive(true);
            other.gameObject.SetActive(false);
            fadingOut = true;
        }
    }

    
}
