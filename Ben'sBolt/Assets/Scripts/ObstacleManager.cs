using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{

    public GameObject electronPrefab;
    public GameObject protonPrefab;
    public GameObject powerupPrefab;

    public float spawnRate = 8f;

    float lastSpawnTime = 0f;
    float lastSpawnTime2 = 0f;

    public int lane1Percent = 33;
    public int lane2Percent = 33;
    public int lane3Percent = 33;   

    // Start is called before the first frame update
    void Update()
    {
        if (!AvatarActions.rideTheLightning && AvatarActions.worldMoving)
        {            
            float spawnChance = Random.Range(1.5f, 3f);
            float spawnChance2 = Random.Range(3f, 6f);

            if (Time.time > lastSpawnTime + spawnRate / GlobalValues.gameSpeed * spawnChance)
            {
                lastSpawnTime = Time.time;
                CreateProton();
            }

            if (Time.time > lastSpawnTime2 + spawnRate / GlobalValues.gameSpeed * spawnChance2)
            {
                lastSpawnTime2 = Time.time;
                CreateElectron();
            }
        }

        if (AvatarActions.rideTheLightning)
        {
            if (Time.time > (lastSpawnTime) + .125)
            {
                lastSpawnTime = Time.time;

                CreatePowerup();
            }
        }
    }
    
    void CreateProton()
    {
        GameObject obj = Instantiate(protonPrefab, transform);
        int randomNumber = Random.Range(0, 99);

        if (randomNumber <= lane1Percent)
        {
            obj.transform.position = new Vector3(-2f, -6, 0);
        }
        else if (randomNumber <= lane1Percent + lane2Percent)
        {
            obj.transform.position = new Vector3(0, -6, 0);
        }
        else
        {
            obj.transform.position = new Vector3(2f, -6, 0);
        }
    }
    void CreateElectron()
    {
        GameObject obj = Instantiate(electronPrefab, transform);
        int randomNumber = Random.Range(0, 99);

        if (randomNumber <= lane1Percent)
        {
            obj.transform.position = new Vector3(-2f, -6, 0);
        }
        else if (randomNumber <= lane1Percent + lane2Percent)
        {
            obj.transform.position = new Vector3(0, -6, 0);
        }
        else
        {
            obj.transform.position = new Vector3(2f, -6, 0);
        }
    }

    void CreatePowerup()
    {
        GameObject obj = Instantiate(powerupPrefab, transform);
        int randomNumber = Random.Range(0, 99);

        if (randomNumber <= lane1Percent)
        {
            obj.transform.position = new Vector3(-2f, -6, 0);
        }
        else if (randomNumber <= lane1Percent + lane2Percent)
        {
            obj.transform.position = new Vector3(0, -6, 0);
        }
        else
        {
            obj.transform.position = new Vector3(2f, -6, 0);
        }
    }
}
