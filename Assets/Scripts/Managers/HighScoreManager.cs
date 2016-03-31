using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour {

    Text text;
	
    void Awake()
    {
        text = GetComponent<Text>();
        text.text = "High Score: " + PlayerPrefs.GetInt("High Score");
    }
}
