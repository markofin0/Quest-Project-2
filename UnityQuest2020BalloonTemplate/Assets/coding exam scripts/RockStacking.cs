using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Copy of the origional rock stacking script so that I can still use it. 
public class RockStacking : MonoBehaviour
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

    // Max number of stackable rocks before it crumbles
    private int rockMax = 4;

    // Audiosource to hold the sound to be played when a rock is stacked
    public AudioSource rockPlaceSound;

    // Set of 4 cubes that Can be stacked 
    public GameObject[] cubes = new GameObject[4];
    // We will manually set this to be the correct objects in the inspector


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
            if (rockCount < 4)
            {
                // Check to make sure that the right cube is being places. 
                if (rock.gameObject.name == cubes[rockCount].gameObject.name)
                {
                    // Start by forcing it to let go, then move it into position with the switch statement
                    rock.gameObject.GetComponent<Rock>().ForceLetGo();

                    rock.transform.position = RockLocations[rockCount].position;
                    rock.transform.rotation = RockLocations[rockCount].rotation;

                    rock.gameObject.GetComponent<Rock>().isPlaced = true;
                    // Hopefully disable the grabbable component. 
                    rock.gameObject.GetComponent<OVRGrabbable>().enabled = false;
                    Debug.Log("placed stone");
                    // Here is where we get to different code, we want it to now add that rock to the array of cubes
                    cubes[rockCount] = rock;

                    rockCount++;
                    // Now set the rock to kinnematic to stop its interactions. 
                    rock.GetComponent<Rigidbody>().isKinematic = true;
                    rockPlaceSound.Play();
                    // And make it so we can no longer pick it up.
                    gameManagerScript.quests[0] = true;
                }

            }
            else
            {
                // We need it to tumble
                rocktumble();
            }
        }


    }

    private void rocktumble()
    {
        // otherwise it needs to tumble. 
        for (int i = 0; i < cubes.Length; i++)
        {
            // Allow physics to apply again
            cubes[i].GetComponent<Rigidbody>().isKinematic = false;
            // Reenable the grabbable
            cubes[i].GetComponent<OVRGrabbable>().enabled = true;
        }
    }
}
