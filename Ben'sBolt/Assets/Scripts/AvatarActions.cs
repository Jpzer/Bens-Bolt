using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class AvatarActions : MonoBehaviour
{
    private int AvatarPosition = 1;
    private int size = 1;
    private float Move = 2f;

    AudioSource sndSwitch;
    AudioSource sndCollide;
    AudioSource sndCollect;
    
    public Text scoreText;
    int score = 1;

    public Text multiText;
    int scoreMulti = 1;

    public static bool worldMoving = true;
    public static bool rideTheLightning = false;
    void Start()
    {
        InvokeRepeating("UpdateText", 1, GlobalValues.gameSpeed/4);

        AudioSource[] src = GetComponents<AudioSource>();

        sndSwitch = src[0];
        sndCollide = src[1];
        sndCollect = src[2];
    }

    void UpdateText()
    {
        if (worldMoving && !rideTheLightning)
        {
            score += scoreMulti;
            scoreText.text = ("Score: " + score);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (worldMoving) {
            if (Input.GetKeyDown(KeyCode.LeftArrow) && AvatarPosition < 2)
            {
                GetComponent<Animator>().SetBool("SwitchL", true);

                transform.Translate(-Move, 0, 0);

                AvatarPosition++;

                Invoke("bruhL", .125f);

                sndSwitch.Play();
            }

            else if (Input.GetKeyDown(KeyCode.RightArrow) && AvatarPosition > 0)
            {
                GetComponent<Animator>().SetBool("SwitchR", true);

                transform.Translate(Move, 0, 0);

                AvatarPosition--;

                Invoke("bruhR", .125f);

                sndSwitch.Play();
            }            
        }
        if (Input.GetKeyDown(KeyCode.Space) && size >= 5)
        {
            if (worldMoving)
            {
                rideTheLightning = true;

                GetComponent<Animator>().SetBool("Attack", true);

                transform.localScale -= new Vector3(0, .25f * size - .25f, 0);
                size = 1;
                scoreMulti = 1;

                Invoke("Powerdown", 4f);
            }
            else
            {
                worldMoving = true;
                SceneManager.LoadScene("Game");
            }
        }
    }

    public void bruhR()
    {
        GetComponent<Animator>().SetBool("SwitchR", false);
    }

    public void bruhL()
    {
        GetComponent<Animator>().SetBool("SwitchL", false);
    }

    public void Powerdown()
    {
        rideTheLightning = false;

        GetComponent<Animator>().SetBool("Attack", false);
    }


    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Electron")
        {
            sndCollect.Play();

            transform.localScale += new Vector3(0, .25f, 0);

            size++;
            scoreMulti++;
            multiText.text = ("Multi: " + scoreMulti + "x");
        }

        else if (other.gameObject.tag == "Obstacle")
        {
            if (!rideTheLightning) 
            {
                sndCollide.Play();

                worldMoving = false;

                size = 5;
                transform.localScale = new Vector3(1, 1, 1);
                GetComponent<Animator>().SetBool("Spark", true);
            }
        }

        else if (other.gameObject.tag == "Powerup")
        {
            scoreMulti = 1;

            score++;
            scoreText.text = ("Score: " + score);
        }
    }
}
