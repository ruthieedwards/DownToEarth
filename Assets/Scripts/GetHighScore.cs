using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetHighScore : MonoBehaviour
{
    public Text scoreText;
	public float bestScore;
	public float currentScore;

    void Start()
    {
        bestScore = PlayerPrefs.GetFloat ("bestScore");
	    currentScore = PlayerPrefs.GetFloat ("currentScore");

        if (currentScore > bestScore) 
        {
			bestScore = currentScore;
			PlayerPrefs.SetFloat("bestScore", bestScore);
		}

        scoreText.text = "S C O R E :     " + currentScore + "                     B E S T :     " + bestScore;
    }
}
