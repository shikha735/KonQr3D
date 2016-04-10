using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour {

    Text text;
    public static int highScore;
	
    void Awake()
    {
        text = GetComponent<Text>();
        highScore = PlayerPrefs.GetInt("HighScore");
        text.text = "High Score: " + highScore;
    }
    void Update()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
        text.text = "High Score: " + highScore;
    }
}
