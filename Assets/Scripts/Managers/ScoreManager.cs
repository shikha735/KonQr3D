using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static int score;

    Text text;

    void Awake ()
    {
        text = GetComponent <Text> ();
        score = 0;
    }

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Level 01")
        {
            score = 0;
        }
        else
        {
            score = PlayerPrefs.GetInt("Score");
        }
    }

    void Update ()
    {
        text.text = "Score: " + score;
    }
}
