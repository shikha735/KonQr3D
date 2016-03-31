﻿using UnityEngine;
using System.Collections;

public class PauseScript : MonoBehaviour {

    public bool paused;

	// Use this for initialization
	void Start () {
        paused = false;
	}
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetKeyDown("p"))
        //{
        //    paused = !paused;
        //}
        //if (paused)
        //{
        //    Time.timeScale = 0;
        //}
        //else if (!paused)
        //{
        //    Time.timeScale = 1;
        //}
    }

    public void Pause()
    {
        paused = !paused;
        if (paused)
        {
            Time.timeScale = 0;
        }
        else if (!paused)
        {
            Time.timeScale = 1;
        }
    }
}
