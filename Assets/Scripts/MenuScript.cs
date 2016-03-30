using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuScript : MonoBehaviour {

    public Canvas quitMenu;
    public Button startButton;
    public Button quitButton;

	// Use this for initialization
	void Start () {
        quitMenu = quitMenu.GetComponent<Canvas> ();
        startButton = startButton.GetComponent<Button>();
        quitButton = quitButton.GetComponent<Button>();
        quitMenu.enabled = false;
	}
	
	public void ExitPress()
    {
        quitMenu.enabled = true;
        startButton.enabled = false;
        quitButton.enabled = false;
    }

    public void NoPress()
    {
        quitMenu.enabled = false;
        startButton.enabled = true;
        quitButton.enabled = true;
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
