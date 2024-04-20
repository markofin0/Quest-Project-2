using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndSceneText : MonoBehaviour
{
    public Text endTextObject;

    //public ArrayList quests = new ArrayList() {false, false, false};
    public GameManagerScript gameManagerScript;
    

    string endText = "";

    void Start()
    {

        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        if ((bool)gameManagerScript.quests[0])
        {
            endText += "You have completed Stone Stacking! ";
        }
        if ((bool)gameManagerScript.quests[1])
        {
            endText += "You have fed the cat! ";
        }
        if ((bool)gameManagerScript.quests[2])
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
