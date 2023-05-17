using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    
    public GameObject   otherBackground;
          
    public int bg1Percent = 33;
    public int bg2Percent = 33;
    public int bg3Percent = 33;

    static int bgCounter = 0;

    static int random = 0;
    // Update is called once per frame
    void Update() {
        if (!AvatarActions.worldMoving)
        {
            bgCounter = 0;
        }
        if (AvatarActions.worldMoving && bgCounter >= 3)
        {
            transform.position += Vector3.up * Time.deltaTime * (GlobalValues.gameSpeed * 2);
        }
        else if (AvatarActions.worldMoving && bgCounter < 3)
        {
            transform.position += Vector3.up * Time.deltaTime * (GlobalValues.gameSpeed / 4);
        }
    }
    private void LateUpdate() { 
            if (transform.position.y >= 10.5) { 
                float otherHalfWidth = otherBackground.GetComponent<SpriteRenderer>().bounds.extents.y;
                float myHalfWidth = GetComponent<SpriteRenderer>().bounds.extents.y;

                float yPos = otherBackground.transform.position.y - otherHalfWidth - myHalfWidth;

                yPos += .5f;
                transform.position = new Vector3(0, yPos);

                bgCounter++;

                if (bgCounter > 4)
                {
                ChangeBackgroundArt();
                         if (gameObject.name == "BG 1") 
                                bgCounter = 0;
                }
                
                else if (bgCounter > 2)
                {
                    GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/BG_Trans");
            }
        }   
    }
    void ChangeBackgroundArt() {
        if (gameObject.name == "BG 2")
        {
            random = Random.Range(0, 99);
        }

        //Debug.Log("yuh");

        if(random <= bg1Percent) { 
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/BG_1");
        }
        else if (random <= bg1Percent + bg2Percent) {
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/BG_4");
        }
        else {
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/BG_3");
        }
    }
}
