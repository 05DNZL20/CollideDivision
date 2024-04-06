using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 5f;
    public float resetSpeed = 5f;
    public float bounceSpeed = 2.5f;
    public int life = 3;
    public int player;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            OpenMenu();
        }

        float moveHorizontal = 0f;
        float moveVertical = 0f;

        if (player == 1)
        {
            if (Input.GetKey(KeyCode.W))
                moveVertical = speed;
            if (Input.GetKey(KeyCode.S))
                moveVertical = -speed;
            if (Input.GetKey(KeyCode.A))
                moveHorizontal = -speed;
            if (Input.GetKey(KeyCode.D))
                moveHorizontal = speed;
        }
        else
        {
            if (Input.GetKey(KeyCode.UpArrow))
                moveVertical = speed;
            if (Input.GetKey(KeyCode.DownArrow))
                moveVertical = -speed;
            if (Input.GetKey(KeyCode.LeftArrow))
                moveHorizontal = -speed;
            if (Input.GetKey(KeyCode.RightArrow))
                moveHorizontal = speed;
        }

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("HighBouncinessObject"))
        {
            rb.velocity *= bounceSpeed;
        }
    }

    public void ResetSpeed()
    {
        speed = resetSpeed;
    }

    public void OpenMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
