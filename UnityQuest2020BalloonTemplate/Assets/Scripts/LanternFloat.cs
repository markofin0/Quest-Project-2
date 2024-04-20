using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternFloat : MonoBehaviour
{
    private OVRGrabbable m_GrabScript;
    public bool hasBeenGrabbed = false;
    public GameManagerScript gameManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        m_GrabScript = GetComponent<OVRGrabbable>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_GrabScript.isGrabbed)
        {
            hasBeenGrabbed = true;
            
        }
        if(!(m_GrabScript.isGrabbed))
        {
            if(hasBeenGrabbed == true)
            {
                transform.position += Vector3.up * Time.deltaTime;
                gameManagerScript.quests[2] = true;
            }
        }
    }
}
