using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    public float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

    private bool w = false;
    private bool a = false;
    private bool s = false;
    private bool d = false;
    private bool space = false;

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

        if(Input.GetKeyDown(KeyCode.W)) w = true;
        if(Input.GetKeyUp(KeyCode.W)) w = false;

        if(Input.GetKeyDown(KeyCode.S)) s = true;
        if(Input.GetKeyUp(KeyCode.S)) s = false;

        if(Input.GetKeyDown(KeyCode.D)) d = true;
        if(Input.GetKeyUp(KeyCode.D)) d = false;

        if(Input.GetKeyDown(KeyCode.A)) a = true;
        if(Input.GetKeyUp(KeyCode.A)) a = false;

        if(Input.GetKeyDown(KeyCode.Space)) space = true;
        if(Input.GetKeyUp(KeyCode.Space)) space = false;

        playerVelocity = new Vector3(0, playerVelocity.y, 0);

        if (w) playerVelocity.z = playerSpeed;
        if (a) playerVelocity.x = -playerSpeed;
        if (s) playerVelocity.z = -playerSpeed;
        if (d) playerVelocity.x = playerSpeed;

/*
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }
*/
        // Changes the height position of the player..
        if (space && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        if(!groundedPlayer) playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}