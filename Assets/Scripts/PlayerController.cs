using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float moveSpeed = 10f;
    public float jumpForce = 5f;
    public bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigidbody component
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Movement controls
        float moveHorizontal = Input.GetAxis("Horizontal"); // A/D or Left/Right Arrow Keys
        float moveVertical = Input.GetAxis("Vertical"); // W/S or Up/Down Arrow Keys

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical) * moveSpeed;

        rb.AddForce(movement);

        // Jump control
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    // Check if the player is grounded
    void OnCollisionStay(Collision collision)
    {
        // Ensure the player is touching the ground to allow jumping
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // Prevent jumping if not on the ground
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = false;
        }
    }
}
