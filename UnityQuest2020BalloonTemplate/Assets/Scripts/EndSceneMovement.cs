using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneMovement : MonoBehaviour
{
    // This script will allow us to move on to the next world

    public void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(2);
    }
}
