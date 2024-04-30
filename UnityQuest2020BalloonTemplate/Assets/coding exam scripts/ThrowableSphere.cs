using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableSphere : MonoBehaviour
{


    // HEre we get the score manager gameobject
    public GameObject scoreManager;

    public ScoreCounter scoreCounter;

    public OVRGrabbable grabPoint;

    public bool hasBeenGrabbed = false;

    public bool hasBeenCounted = false;
    // Start is called before the first frame update
    void Start()
    {
        grabPoint = GetComponent<OVRGrabbable>();
    }

    // Update is called once per frame
    void Update()
    {
        // If it has been grabbed
        if(grabPoint.isGrabbed && !hasBeenGrabbed)
        {
            hasBeenGrabbed=true;
            // Next we can get the scoreManager
        }
        // If it has been grabbed, AND isnt currently being grabbed, we can start the vanish routine
        if(hasBeenGrabbed && !grabPoint.isGrabbed)
        {
            if (!hasBeenCounted)
            {
                hasBeenCounted=true;
                scoreCounter.IncreaseScore(1);
                StartCoroutine(vanishSphere(3));
            }
        }
    }

    IEnumerator vanishSphere(int i)
    {
        yield return new WaitForSeconds(i);
        Destroy(this.gameObject);
    }
}
