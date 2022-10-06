using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class modController : MonoBehaviour
{
    //Contains: modcontroller, pickup count

    [Header("Set in Inspector")]
    public float speed = 0;
    public Text uitPickUp;
    //public Text winText;
    public Text uitWelcome;
    public Text uitFlag;

    private Rigidbody rb;
    private int pickUpCount;
    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pickUpCount = 0;
        uitWelcome.enabled = true;
        Invoke("welcomeDecay", 7f);
        uitFlag.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Main-Prototype 1");
        }
    }
    void welcomeDecay()
    {
        uitWelcome.enabled = false;
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }
    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    void SetPUCount()
    {
        uitPickUp.text = "Coins: " + (pickUpCount);
    }

    void needCoins()
    {
        uitFlag.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            pickUpCount = pickUpCount + 1;

            SetPUCount();
        }
        if (other.gameObject.CompareTag("Death"))
        {
            SceneManager.LoadScene("Main-Prototype 1");
        }
        if (other.gameObject.CompareTag("Flag"))
        {
            if (pickUpCount < 5)
            {
                print("if-else should be working.");
                uitFlag.text = "You only have " + pickUpCount + " Coins. Come back with 5!";
                uitFlag.enabled = true;
                Invoke("needCoins", 3f);
            }
            else
                {
                uitFlag.text = "You Win! Hit E to restart.";
                uitFlag.enabled = true;
            }
        }
    }
}
