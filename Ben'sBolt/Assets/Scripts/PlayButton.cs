using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Invoke("StartGame", .25f);
        }
    }

    void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
}
