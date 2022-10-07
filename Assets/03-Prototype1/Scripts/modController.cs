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
    public Text uitBreak;

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
        uitBreak.enabled = false;
    }
    void welcomeDecay()
    {
        uitWelcome.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Main-Prototype 1");
        }
    }
    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetPUCount()
    {
        uitPickUp.text = "Coins: " + (pickUpCount);
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
                uitFlag.text = "You only have " + pickUpCount + " Coins. Come back with 5!";
                uitFlag.enabled = true;
                //Invoke("needCoins", 3f); //realized I could just do onTriggerEnter enable and onTriggerExit set to false
            }
            else
                {
                uitFlag.text = "You Win! Hit 'R' to restart.";
                uitFlag.enabled = true;
            }
        }
    }

private void OnTriggerStay(Collider other){
        if (other.gameObject.CompareTag("canBreak"))
        {
            uitBreak.text = "Hit 'E' to break crate";
            uitBreak.enabled = true;
            if (Input.GetKeyDown(KeyCode.E)) //problem with this working. Ask prof? //can create a script for the cube that is looking for a msg from this code to give permission to break.
            {
                Debug.Log("pressing E"); //more options alt to print
                other.gameObject.SetActive(false);
                //Destroy(other.gameObject);
            }

        }
}

    private void OnTriggerExit(Collider other)
    {
        uitFlag.enabled = false;
        uitBreak.enabled = false;
    }
}
