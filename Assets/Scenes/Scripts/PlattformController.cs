using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlattformController : MonoBehaviour
{
    Rigidbody rb;
    PlayerController playerController;
    public Canvas gameOverCanvas;
    public TextMeshProUGUI gameOverText;
    // Start is called before the first frame update
    void Start()
    {
        gameOverCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();

        if (rb != null && rb.transform.position.y < transform.localScale.y)
        {
            PlayerController playerController = rb.GetComponent<PlayerController>();

            if (playerController != null)
            {
                playerController.life--;

                if (playerController.life > 0)
                {
                    StartCoroutine(RespawnPlayer(playerController));
                }
                else
                {
                    gameOverCanvas.enabled = true;
                    if (playerController.player == 1) { 
                        gameOverText.text = "Player 2 has won!";
                    } else {
                        gameOverText.text = "Player 1 has won!";
                    }
                   
                }
            }
        }
    }

    IEnumerator RespawnPlayer(PlayerController playerController)
    {
        GameObject playerPrefab = playerController.gameObject;

        yield return new WaitForSeconds(1f);

        GameObject newPlayer = Instantiate(playerPrefab, new Vector3(0f, 16.5f, 0f), Quaternion.identity);

        PlayerController newPlayerController = newPlayer.GetComponent<PlayerController>();
        newPlayerController.life = playerController.life;
        newPlayerController.player = playerController.player;

        Destroy(playerController.gameObject);
    }
}
