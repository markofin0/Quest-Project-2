using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treat : MonoBehaviour
{
    // So, this will hold the cat object, and when we want the cat to eat the treat, we will deal with it here. 
    public OVRGrabbable grab;

    public GameObject cat;

    public CatControler CatControler;

    public AudioSource eatSound; 

    public void Start()
    {
        CatControler = cat.GetComponent<CatControler>();
        grab = GetComponent<OVRGrabbable>();
    }

    public void feedCat()
    {
        CatControler.eatTreat();
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("CatEat"))
        {
            feedCat();
            eatSound.Play();
            grab.grabbedBy.ForceRelease(grab);
            Destroy(this.gameObject);


        }
    }
}
