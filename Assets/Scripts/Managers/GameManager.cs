using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public float levelStartDelay = 2f;
    public float restartDelay = 5f;
    public float levelOneMaxScore = 50;
    public float levelTwoMaxScore = 100;
    public float levelThreeMaxScore = 150;

    public Text levelText;
    public int level = 1;
    public GameObject levelImage;
    private bool doingSetUp;
    Animator anim;
    private float restartTimer = 0;
    private float levelStartTimer = 0;


    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnLevelWasLoaded(int index)
    {
        InitGame();
    }

    void InitGame()
    {
        doingSetUp = true;
        // levelImage = GameObject.Find("LevelImage");
        // levelText = GameObject.Find("LevelText").GetComponent<Text>();
        levelText.text = "Level 0" + level;
        levelImage.SetActive(true);
        Invoke("HideLevelImage", levelStartDelay);
    }

    private void HideLevelImage()
    {
        levelImage.SetActive(false);
        doingSetUp = false;
    }

    void Update()
    {
        SaveScores();
        
        if (playerHealth.currentHealth <= 0)
        {
            PlayerPrefs.DeleteKey("Score");
            anim.SetTrigger("GameOver");
            restartTimer += Time.deltaTime;
            
            if(restartTimer >= restartDelay)
            {
                SceneManager.LoadScene(0);
            }
        }
        if (doingSetUp)
        {
            return;
        }
        if (ScoreManager.score >= levelOneMaxScore)
        {
            if (SceneManager.GetActiveScene().name == "Level 01")
            {
                levelStartTimer += Time.deltaTime;
                if(levelStartTimer >= levelStartDelay)
                {
                    StartCoroutine(LevelChange());
                    SceneManager.LoadScene("Level 02");
                }
            }
        }
        if (ScoreManager.score >= levelTwoMaxScore)
        {
            if (SceneManager.GetActiveScene().name == "Level 02")
            {
                levelStartTimer += Time.deltaTime;
                if (levelStartTimer >= levelStartDelay)
                {
                    StartCoroutine(LevelChange());
                    SceneManager.LoadScene("Level 03");
                }
            }
        }

        if(ScoreManager.score >= levelThreeMaxScore)
        {
            // Player wins
            SceneManager.LoadScene(4);
        }
    }

    void SaveScores()
    {
        PlayerPrefs.SetInt("HighScore", HighScoreManager.highScore);
        PlayerPrefs.SetInt("Score", ScoreManager.score);

        if (PlayerPrefs.GetInt("Score") > PlayerPrefs.GetInt("HighScore"))
        {
            HighScoreManager.highScore = ScoreManager.score;
            PlayerPrefs.SetInt("HighScore", HighScoreManager.highScore);
        }
    }

    IEnumerator LevelChange()
    {
        float fadeTime = GameObject.Find("HUDCanvas").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
    }
}
