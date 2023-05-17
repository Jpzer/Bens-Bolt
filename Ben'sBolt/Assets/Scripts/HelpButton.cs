using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HelpButton : MonoBehaviour
{
    // Start is called before the first frame update
    void OnMouseDown()
    {
        SceneManager.LoadScene("HowToPlay");

        AudioSource sndClick;
        AudioSource src = GetComponent<AudioSource>();

        sndClick = src;

        sndClick.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
