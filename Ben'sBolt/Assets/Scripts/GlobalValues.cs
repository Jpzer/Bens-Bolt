using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalValues : MonoBehaviour
{
    public static float gameSpeed;

    private void Start()
    {
        gameSpeed = 5;
    }

    void Update()
    {
        if (AvatarActions.worldMoving)
            gameSpeed += Time.deltaTime / 8;
    }
}
