using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plank : MonoBehaviour
{
    public int objectCounter = 0;
    public Oculus.Interaction.Grabbable plankGrabbableScript;


    // Start is called before the first frame update
    void Awake()
    {
        //Gets the Plank's Grabbale component
        plankGrabbableScript = gameObject.GetComponent<Oculus.Interaction.Grabbable>();
        plankGrabbableScript.enabled = false; // Disable the Plank's grabbale component so that it is immovable
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // when object counter is 5 then the user should be able to move the plank
        if (objectCounter == 5)
        {
            plankGrabbableScript.enabled = true;
        }
    }

   

    public void OnTriggerEnter(Collider other)
    {
        // Skull Object feedback
        if (other.gameObject.tag.Contains("Obj-"))
        {
            Debug.Log(other.gameObject.transform.name+" is on Plank now.");
            //other.gameObject.GetComponent<Rigidbody>().useGravity = true;
            other.transform.SetParent(transform);
            objectCounter += 1;
        }
    }
}
