using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuScript : MonoBehaviour {

    public Canvas quitMenu;
    public Canvas controlsCanvas;
    public Button startButton;
    public Button quitButton;
    public Button controlsButton;

	// Use this for initialization
	void Start () {
        quitMenu = quitMenu.GetComponent<Canvas> ();
        controlsCanvas = controlsCanvas.GetComponent<Canvas>();
        startButton = startButton.GetComponent<Button>();
        quitButton = quitButton.GetComponent<Button>();
        controlsButton = controlsButton.GetComponent<Button>();
        quitMenu.enabled = false;
        controlsCanvas.enabled = false;
    }
	
	public void ExitPress()
    {
        quitMenu.enabled = true;
        controlsCanvas.enabled = false;
        startButton.enabled = false;
        quitButton.enabled = false;
        controlsButton.enabled = false;
    }

    public void NoPress()
    {
        quitMenu.enabled = false;
        controlsCanvas.enabled = false;
        startButton.enabled = true;
        quitButton.enabled = true;
        controlsButton.enabled = true;
    }

    public void ControlsPress()
    {
        quitMenu.enabled = false;
        controlsCanvas.enabled = true;
        startButton.enabled = false;
        quitButton.enabled = false;
        controlsButton.enabled = false;
    }
    
    public void StartLevel()
    {
        SceneManager.LoadScene("Level 01");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
