using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsButton : MonoBehaviour
{
    // Start is called before the first frame update
    void OnMouseDown()
    {
        SceneManager.LoadScene("Credits");

        AudioSource sndClick;
        AudioSource src = GetComponent<AudioSource>();

        sndClick = src;

        sndClick.Play();
    }
}
