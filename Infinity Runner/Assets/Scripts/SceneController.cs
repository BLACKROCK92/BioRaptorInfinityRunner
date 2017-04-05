﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

    public void GameScene()
    {
        SceneManager.LoadScene("Main");
    }

    public void MenuScene()
    {
        SceneManager.LoadScene("Menu");
    }
}
