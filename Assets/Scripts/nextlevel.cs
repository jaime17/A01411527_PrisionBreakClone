﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextlevel : MonoBehaviour {

    public void LoadLevel(string LevelName)
    {
        SceneManager.LoadScene(LevelName);
    }
    public void EndGame()
    {
        Application.Quit();
    }
}
