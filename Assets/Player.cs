using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    public float playerSpeed = 2.0f;
    public float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    private int score = 0;
    public int maxHealth = 4;
    private int health;
    public Text text_score;
    public Text text_health;

    private int untouchableTime = 0;
    private int untouchableMaxTime = 10;
    private bool untouchable = false;

    private float startTime = 0.0f;
    private int seconds = 0;
    private bool timerOn = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
        health = maxHealth;
        text_health.text = "Health: " + health;
    }

    void Update()
    {
        if (untouchable) {
            untouchableTime++;
            if (untouchableTime > untouchableMaxTime) {
                untouchable = false;
                untouchableTime = 0;
            }
        }

        if (timerOn) {
            //timer += Time.deltaTime;
            seconds = (int)((Time.time - startTime) % 60);
            updateScore();
        }

        rb.AddForce(new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")) * playerSpeed);

        if (Input.GetButtonDown("Jump")) rb.AddForce(Vector3.up*jumpHeight, ForceMode.Impulse);

        /*
        if (space && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        if(!groundedPlayer) playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
        */
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("coin")) {
            Destroy(other.gameObject);
            addScore(1);
        }
        if (other.gameObject.CompareTag("scorer")) {
            Destroy(other.gameObject);
            addScore(1);
            if(!timerOn) startTime = Time.time;
            timerOn = true;
        }
        if (other.gameObject.CompareTag("specialcoin")) {
            Destroy(other.gameObject);
            addScore(10);
        }
        if (other.gameObject.CompareTag("hp")) {
            Destroy(other.gameObject);
            addHealth(1);
        }
    }

    private void OnCollisionEnter(Collision col) {
        if (col.gameObject.CompareTag("enemy"))
        {
            if (!untouchable)
            {
                takeDamage(1);
                untouchable = true;
            }
        }
    }

    private void updateScore() {
        float scorePerSecond = (float)score / (float)seconds;
        int finalScore = seconds != 0 ? score * score / seconds : score;
        text_score.text = "Score: " + finalScore;
    }

    private void addScore(int sc) {
        score += sc;
        //text_score.text = "Score: " + score;
    }

    private void addHealth(int hp) {
        health += hp;
        text_health.text = "Health: " + health;
    }

    private void takeDamage(int dmg) {
        health -= dmg;
        text_health.text = "Health: " + health;

        if(health < 1) Application.LoadLevel(Application.loadedLevel);
    }
}