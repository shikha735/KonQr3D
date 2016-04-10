using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public float levelStartDelay = 2f;
    public float levelOneMaxScore = 50;
    public float levelTwoMaxScore = 100;
    public float levelThreeMaxScore = 150;

    public Text levelText;
    public int level = 1;
    public GameObject levelImage;
    private bool doingSetUp;
    Animator anim;


    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnLevelWasLoaded(int index)
    {
        Debug.Log("On level was loaded");
        InitGame();
    }

    void InitGame()
    {
        Debug.Log("Init Game");
        doingSetUp = true;
        // levelImage = GameObject.Find("LevelImage");
        // levelText = GameObject.Find("LevelText").GetComponent<Text>();
        levelText.text = "Level 0" + level;
        levelImage.SetActive(true);
        Invoke("HideLevelImage", levelStartDelay);
    }

    private void HideLevelImage()
    {
        Debug.Log("Hide level image");
        levelImage.SetActive(false);
        doingSetUp = false;
    }

    void Update()
    {
        if (playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger("GameOver");
        }
        if (doingSetUp)
        {
            Debug.Log("if doing setup");
            return;
        }
        if (ScoreManager.score >= levelOneMaxScore)
        {
            if (SceneManager.GetActiveScene().name == "Level 01")
            {
                Debug.Log("Level 2 loading");
                StartCoroutine(LevelChange());
                SceneManager.LoadScene("Level 02");
            }
        }
        if (ScoreManager.score >= levelTwoMaxScore)
        {
            if (SceneManager.GetActiveScene().name == "Level 02")
            {
                Debug.Log("Level 3 loading");
                LevelChange();
                SceneManager.LoadScene("Level 03");
            }
        }
    }

    IEnumerator LevelChange()
    {
        float fadeTime = GameObject.Find("HUDCanvas").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
    }
}
