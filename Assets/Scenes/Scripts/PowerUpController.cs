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
    private void OnTriggerEnter(Collider other)
    {

        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        float originalSpeed = player.speed;
        if (player != null)
        {
            player.speed += 10f;
        }

        StartCoroutine(WaitSomeSeconds());
        player.speed = originalSpeed;


        gameObject.SetActive(false);

        SpawnerController spawnerController = FindObjectOfType<SpawnerController>();
        if (spawnerController != null)
        {
            spawnerController.isPowerUpActive = false;
        }

    }

    IEnumerator WaitSomeSeconds()
    {
        yield return new WaitForSeconds(2f);
    }

}
