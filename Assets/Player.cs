using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        if(Input.GetKeyDown(KeyCode.W)) {
            playerVelocity.z = 5;
        }

        if(Input.GetKeyUp(KeyCode.W)) {
            playerVelocity.z = 0;
        }

        if(Input.GetKeyDown(KeyCode.S)) {
            playerVelocity.z = -5;
        }

        if(Input.GetKeyUp(KeyCode.S)) {
            playerVelocity.z = 0;
        }
        if(Input.GetKeyDown(KeyCode.D)) {
            playerVelocity.x = 5;
        }

        if(Input.GetKeyUp(KeyCode.D)) {
            playerVelocity.x = 0;
        }

        if(Input.GetKeyDown(KeyCode.A)) {
            playerVelocity.x = -5;
        }

        if(Input.GetKeyUp(KeyCode.A)) {
            playerVelocity.x = 0;
        }

/*
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        */
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}