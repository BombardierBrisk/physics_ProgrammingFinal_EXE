﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RestartGame()
    {
        Application.LoadLevel(0);
    }



    public void QuitGame()
    {
        Application.Quit();
    }
}
