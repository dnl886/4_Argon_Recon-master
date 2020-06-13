﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadNextScene", 2f);
    }

    // Update is called once per frame
    void LoadNextScene()
    {
        SceneManager.LoadScene(1);
    }
}