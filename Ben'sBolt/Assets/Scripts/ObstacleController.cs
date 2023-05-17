using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleController : MonoBehaviour
{

    //speedAdjustment needs to be added later if ever
    public float speedAdjustment = 2f;

   
    // Update is called once per frame
    void Update()
    {
        if (AvatarActions.worldMoving)
        {
            transform.position += Vector3.up * Time.deltaTime * (GlobalValues.gameSpeed + speedAdjustment);
        }

        if (transform.position.y > 6)
        {
            Object.Destroy(gameObject);
        }
        if (gameObject.tag == "Obstacle" && AvatarActions.rideTheLightning)
        {
            Object.Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Object.Destroy(gameObject);
    }
}
