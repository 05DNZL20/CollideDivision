using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private async void OnTriggerEnter(Collider other)
    {

        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        float originalSpeed = player.speed;
        if (player != null)
        {
            player.speed += 10f;
        }

        gameObject.SetActive(false);

        SpawnerController spawnerController = FindObjectOfType<SpawnerController>();
        if (spawnerController != null)
        {
            spawnerController.isPowerUpActive = false;
        }

        await Task.Delay(4000);
        player.speed = originalSpeed;
    }

}
