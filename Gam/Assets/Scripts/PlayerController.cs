using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementMultiplier;
    public CharacterController controller;
    public float jumpForce;
    
    private Vector3 playerVelocity;
    private float gravityValue = -9.81f * 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        if (!enabled)
        {
            return;
        }
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        move = transform.rotation * move;
        
        controller.Move(move * movementMultiplier * Time.deltaTime);

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        bool grounded = false;
        
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 10, ~6))
        {
            if (hit.distance <= 1.01f)
                grounded = true;
        }
        
        if (grounded)
            playerVelocity = Vector3.zero;

        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("A");
            playerVelocity.y = jumpForce;
        }
    }
}
