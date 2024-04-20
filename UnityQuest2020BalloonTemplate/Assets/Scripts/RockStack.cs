using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockStack : MonoBehaviour
{
    /*
    // So this will represent a stack of rocks for the player. it will hold 3 positions(empty objects with transforms) and we will be able to have a rock snap into place this way. 
    public GameObject snap1;
    public GameObject snap2;
    public GameObject snap3;
    // Now the transforms of the snap spots, what we actually care about lol
    public Transform snap1T;
    public Transform snap3T; 
    public Transform snap2T;
    */

    // Idea for this came from the textbook
    public Transform rockbase;
    public List<Transform> RockLocations;

    // Int to track the number of stacked objects we currently have. 
    private int rockCount = 0; 

    // Audiosource to hold the sound to be played when a rock is stacked
    public AudioSource rockPlaceSound;


    public GameManagerScript gameManagerScript;

    public void Start()
    {
        /*
        snap1T = snap1.transform;
        snap2T = snap2.transform;
        snap3T = snap3.transform;
        */
        
        foreach (Transform child in rockbase)
        {

            RockLocations.Add(child);
        }
        

    }

    // This will handle the specefic logic between snapping the object to each position. 
    public void OnTriggerEnter(Collider other)
    {
        // If the object is a rock. 
        if (other.gameObject.tag == "Rock" && other.gameObject.GetComponent<Rock>().isPlaced == false)
        {
            GameObject rock = other.gameObject;
            // If the count of rocks is less than 3, we can start the other checks
            if (rockCount < RockLocations.Count)
            {
                // Start by forcing it to let go, then move it into position with the switch statement
                rock.gameObject.GetComponent<Rock>().ForceLetGo();

                rock.transform.position = RockLocations[rockCount].position;
                rock.transform.rotation = RockLocations[rockCount].rotation;

                rock.gameObject.GetComponent<Rock>().isPlaced = true;
                // Hopefully disable the grabbable component. 
                rock.gameObject.GetComponent<OVRGrabbable>().enabled = false;
                Debug.Log("placed stone");
                rockCount++;
                // Now set the rock to kinnematic to stop its interactions. 
                rock.GetComponent<Rigidbody>().isKinematic = true;
                rockPlaceSound.Play();
                // And make it so we can no longer pick it up.
                gameManagerScript.quests[0] = true;


                    
            }
        }

        
    }
}
