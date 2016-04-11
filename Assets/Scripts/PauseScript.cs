using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{

    public bool paused;
    public Canvas menuCanvas;
    public Canvas helpCanvas;
    public float restartDelay = 5f;

    private float restartTimer = 0;
    private bool restartCalled = false;

    // Use this for initialization
    void Start()
    {
        menuCanvas = menuCanvas.GetComponent<Canvas>();
        helpCanvas = helpCanvas.GetComponent<Canvas>();
        paused = false;
        menuCanvas.enabled = false;
        helpCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            Pause();
        }
        if (restartCalled)
        {
            restartTimer += Time.deltaTime;
        }
    }

    public void Pause()
    {
        paused = !paused;
        if (paused)
        {
            menuCanvas.enabled = true;
            helpCanvas.enabled = false;
            Time.timeScale = 0;
        }
        else if (!paused)
        {
            menuCanvas.enabled = false;
            helpCanvas.enabled = false;
            Time.timeScale = 1;
        }
    }

    public void ResumePress()
    {
        menuCanvas.enabled = false;
        helpCanvas.enabled = false;
        Time.timeScale = 1;
    }

    public void RestartPress()
    {
        //restartCalled = true;

        //if (restartTimer >= restartDelay)
        //{
        //    SceneManager.LoadScene("Level 01");
        //}
        SceneManager.UnloadScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("Start");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenuPress()
    {
        SceneManager.UnloadScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(0);
    }

    public void HelpPress()
    {
        menuCanvas.enabled = false;
        helpCanvas.enabled = true;
    }

    public void ControlsPress()
    {
        helpCanvas.enabled = false;
        menuCanvas.enabled = true;
    }
}
