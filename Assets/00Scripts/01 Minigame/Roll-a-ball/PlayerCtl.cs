using System;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.InputSystem;

public class PlayerCtl : MonoBehaviour
{
    private PlayerInput playerInput;
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    public float speed = 1f;
    public TextMeshProUGUI text;
    public GameObject winTextObject;
    private int count = 0;
    [SerializeField] private Transform PickUps;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
        SetCountText();

    }

    void OnMove(InputValue movementValue)
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
    void OnTriggerEnter(Collider other)
    {
        // Check if the object the player collided with has the "PickUp" tag.
        if (other.gameObject.CompareTag("PickUp"))
        {
            // Deactivate the collided object (making it disappear).
            other.gameObject.SetActive(false);
            count++;    
            SetCountText();

        }
    }
    void SetCountText()
    {
        // Update the count text with the current count.
        text.text = "Count: " + count.ToString();

        // Check if the count has reached or exceeded the win condition.
        if (count >= PickUps.childCount)
        {
            // Display the win text.
            winTextObject.SetActive(true);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Destroy the current object
            Destroy(gameObject);

            // Update the winText to display "You Lose!"
            winTextObject.gameObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose!";

        }

    }
}
