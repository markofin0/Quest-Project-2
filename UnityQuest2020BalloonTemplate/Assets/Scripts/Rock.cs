using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    // This script will represent a single rock in the setup
    // Grabbale to manage the interaction components
    private OVRGrabbable grabbable;
    // Boolean to check if an object has been placed yet
    public bool isPlaced = false; 
    private void Start()
    {
        grabbable = GetComponent<OVRGrabbable>();
    }


    // This function SHOULD, let me force the object to be released, then we can just do all the work in the stack. 
    public void ForceLetGo()
    {
        if(grabbable.isGrabbed)
        {
            grabbable.grabbedBy.ForceRelease(grabbable);
            grabbable.enabled = false; // Once its forced to be released it should be in its final place. 
        }
    }
}
