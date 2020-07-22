using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class ScoringSystem : MonoBehaviour
{
    public Text floraText;
    public Text faunaText;
    public Text scoreText;
    public int floraNumber;
    public int faunaNumber;
    public int scoreNumber = 0;

    // simple script to keep the score text updated
    void Update()
    {
        floraText.text = "" + floraNumber; 
        faunaText.text = "" + faunaNumber; 
        scoreText.text = "" + scoreNumber; 

        // tells the player how many plants & animals are remaining
        floraNumber = GameObject.FindGameObjectsWithTag("flora").Length;
        faunaNumber = GameObject.FindGameObjectsWithTag("fauna").Length;

        if (floraNumber == 0 && faunaNumber == 0)
		{
			// if all the plants & animals die, it's game over
            PlayerPrefs.SetFloat("currentScore", scoreNumber);
            SceneManager.LoadScene(2);
		}




    }
}
