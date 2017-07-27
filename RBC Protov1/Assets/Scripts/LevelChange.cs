﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour {

    public string level;

    public void LevelChanger()
    {
        SceneManager.LoadScene(level);
    }
}