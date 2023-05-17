using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsMovementR : MonoBehaviour
{
    public float        speed = 5f;
    public GameObject   otherBackground;

    // Update is called once per frame
    void Update()
    {
        if (AvatarActions.worldMoving)
        {
            transform.position += Vector3.up * Time.deltaTime * GlobalValues.gameSpeed;
        }
    }
    private void LateUpdate()
    {
        if (transform.position.y >= 10.5)
        {
            float otherHalfWidth = otherBackground.GetComponent<SpriteRenderer>().bounds.extents.y;
            float myHalfWidth = GetComponent<SpriteRenderer>().bounds.extents.y;

            float yPos = otherBackground.transform.position.y - otherHalfWidth - myHalfWidth;

            yPos += 1.5f;

            transform.position = new Vector3(6.7f, yPos);
        }
    }
}
