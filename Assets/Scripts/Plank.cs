using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plank : MonoBehaviour
{
    public int objectCounter = 0;
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
        if (other.gameObject.tag.Contains("Obj-"))
        {
            Debug.Log(other.gameObject.transform.name+" is on Plank now.");
            //other.gameObject.GetComponent<Rigidbody>().useGravity = true;
            other.transform.SetParent(transform);
            objectCounter += 1;
        }
    }
}
