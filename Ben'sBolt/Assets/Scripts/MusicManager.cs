using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("MenuMusic");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Update()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");

        if (!AvatarActions.worldMoving)
        {
            Destroy(this.gameObject);
        }
    }
}
