using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour {

    public bool paused;
    public Canvas menuCanvas;
    public Canvas helpCanvas;

	// Use this for initialization
	void Start () {
        menuCanvas = menuCanvas.GetComponent<Canvas>();
        helpCanvas = helpCanvas.GetComponent<Canvas>();
        paused = false;
        menuCanvas.enabled = false;
        helpCanvas.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("p"))
        {
            Pause();
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
        Time.timeScale = 1;
    }

    public void RestartPress()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenuPress()
    {
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
