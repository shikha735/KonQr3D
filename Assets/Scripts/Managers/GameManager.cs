using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerHealth playerHealth;


    Animator anim;


    void Awake()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger("GameOver");
        }
        if (ScoreManager.score >= 50)
        {
            if (SceneManager.GetActiveScene().name == "Level 01")
            {
                SceneManager.LoadScene("Level 02");
            }
        }
        if (ScoreManager.score >= 100)
        {
            if (SceneManager.GetActiveScene().name == "Level 02")
            {
                SceneManager.LoadScene("Level 03");
            }
        }
    }
}
