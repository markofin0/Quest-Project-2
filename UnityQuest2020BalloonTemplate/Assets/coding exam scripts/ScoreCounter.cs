using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{

    public Text scoreText;
    public int score = 0;
    public string[] ScoreMessages = new string[5];

    public void Start()
    {
        //scoreText = GetComponent<Text>();  
        scoreText.text = "working";
       
    }
    public void IncreaseScore(int i)
    {
        score += 1;
        scoreText.text = "Score: " + score + "\n" + ScoreMessages[score];
      
    }

    IEnumerator RemoveScoreText()
    {
        yield return new WaitForSeconds(3);
        scoreText.text = "";
    }
}
