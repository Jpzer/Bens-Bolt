﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    void OnMouseDown()
    {
        SceneManager.LoadScene("Main Menu");

        AudioSource sndBack;
        AudioSource[] src = GetComponents<AudioSource>();

        sndBack = src[0];

        sndBack.Play();
    }
}
