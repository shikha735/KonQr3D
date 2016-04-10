using UnityEngine;
using System.Collections;

public class Fading : MonoBehaviour {

    public Texture2D fadeOutTexture; // Texture that will overlay the screen
    public float fadeSpeed; // fading speed

    private int drawDepth = -1000; // texture's order in heirarchy; Rendered on top
    private float alpha = 1.0f; // texture's alpha between 0 and 1
    private int fadeDir = -1; // Direction to fade: in =-1 and out = 1

	void OnGUI()
    {
        // Unity's function for rendering GUI

        // fade in/out alpha
        alpha += fadeDir * fadeSpeed * Time.deltaTime;

        // clamp the number between 0 and 1 becuase GUI.aplha uses values between 0 and 1
        alpha = Mathf.Clamp01(alpha);

        // set color of GUI(Canvas); color values remain the same, Alpha value is set to alpha variable
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;                                                          // make black texture render on top
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);   // draw texture to fit entire screen
    }

    // sets fade direction (fadeDir)
    public float BeginFade (int direction)
    {
        fadeDir = direction;
        return (3)/*fadeSpeed*/; // return fadeSpeed so that it is easy to time SceneManager.LoadScene
    }

   void OnLevelWasLoaded()
    {
        // alpha = 1; if alpha is not initialized then do it here
        BeginFade(-1); // call fade in function
    }
}
