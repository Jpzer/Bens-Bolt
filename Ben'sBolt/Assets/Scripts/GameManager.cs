using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOver = null;

    private void Start()
    {
        gameOverDeactivate();           
    }
    void Update()
    {
        if (!AvatarActions.worldMoving)
        {
            gameOverActivate();
        }
       
    }
    public void gameOverActivate()
    {
        gameOver.SetActive(true);
    }
    public void gameOverDeactivate()
    {
        gameOver.SetActive(false);
    }
}