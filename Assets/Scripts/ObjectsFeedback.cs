using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsFeedback : MonoBehaviour
{
    Transform[] skullMagicCircleChildObjects;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        // Skull Object feedback
        if (other.gameObject.CompareTag("Skull Circle"))
        {
            Debug.Log("Entering Trigger Zone - Skull Circle");
            skullMagicCircleChildObjects = other.gameObject.GetComponentsInChildren<Transform>();
 
            for(int i = 1; i < 4; i++)
            {
                Debug.Log(skullMagicCircleChildObjects[i].name);
                skullMagicCircleChildObjects[i].gameObject.SetActive(false);
            }
           
        }
    }
    public void OnTriggerExit(Collider other)
    {
        // Skull Object feedback
        if (other.gameObject.CompareTag("Skull Circle"))
        {
            Debug.Log("Exiting Trigger Zone - Skull Circle");
           

            for (int i = 1; i < 4; i++)
            {
                Debug.Log(skullMagicCircleChildObjects[i].name);
                skullMagicCircleChildObjects[i].gameObject.SetActive(true);
            }

        }
    }
}
