using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndSceneText : MonoBehaviour
{
    public Text endTextObject;

    public ArrayList quests = new ArrayList() {false, false, false};
    string endText = "";

    void Start()
    {
        if ((bool)quests[0])
        {
            endText += "You have completed Stone Stacking! ";
        }
        if ((bool)quests[1])
        {
            endText += "You have completed Pet Sit! ";
        }
        if ((bool)quests[2])
        {
            endText += "You have floated some lanterns! ";
        }

        // Update the Text component with the end text
        if (endTextObject != null)
        {
            endTextObject.text = endText;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
