using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{

    public ArrayList quests = new ArrayList() { false, false, false };

    public void Start()
    {
        DontDestroyOnLoad(this.gameObject);

    }

}
