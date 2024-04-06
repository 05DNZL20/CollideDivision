using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public GameObject spawnerObject;
    private GameObject plattform;
    public float minSpawnTime = 5f;
    public float maxSpawnTime = 15f;
    private float timer;
    public bool isPowerUpActive = false;
    // Start is called before the first frame update
    void Start()
    {
        plattform = GameObject.FindWithTag("Plattform");
        timer = Random.Range(minSpawnTime, maxSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0 && isPowerUpActive == false)
        {
            Vector3 pos = SetPositionPowerUp(plattform);
            Instantiate(spawnerObject, pos, Quaternion.identity);
            isPowerUpActive = true;

            timer = Random.Range(minSpawnTime, maxSpawnTime);
        }

    }
    Vector3 SetPositionPowerUp(GameObject squarePlatform)
    {
        float halfScaleZ = squarePlatform.transform.localScale.x / 2;
        float halfScaleX = squarePlatform.transform.localScale.z / 2;


        Vector3 center = squarePlatform.transform.position;

        Vector3 randomPosition = new Vector3(
            Random.Range(center.x - halfScaleX, center.x + halfScaleX),
            14.0f,
            Random.Range(center.z - halfScaleZ, center.z + halfScaleZ)
        );

        return randomPosition;
    }
}
