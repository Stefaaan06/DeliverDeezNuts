using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerController : MonoBehaviour
{
    [Header("Values:")]
    public float speed = 5.0f; 
    public float cameraFollowSpeed = 10.0f; 
    public float pushForce = 10.0f; 
    public float throwSpeed = 10.0f; 
    public float gravity = -9.81f;
    public int numMarkers = 10;

    [Header("References:")]
    [SerializeField] CharacterController controller;
    [SerializeField] GameObject playerCapsule;
    [SerializeField] Transform mainCameraTransform;
    [SerializeField] Transform shootingPos;
    [SerializeField] Transform oldPos;
    [SerializeField] GameObject hand1;
    [SerializeField] Transform target;
    [SerializeField] GameObject nutThrow;
    [SerializeField] Transform throwPos;
    [SerializeField] nutHandler handler;
    [SerializeField] TMP_Text text;
    private Vector3 cameraOffset;

    float multiplier = 1f;
    int points = 0;
    public int killedEnemies = 0;

    bool stopwatchActive = false;
    float currentTime = 0;
    [SerializeField] TMP_Text currentTimeText;
    [SerializeField] GameObject statsMenu;
    [SerializeField] TMP_Text timeText;
    [SerializeField] TMP_Text enemies;
    [SerializeField] TMP_Text nuts;
    [SerializeField] TMP_Text totalPoints;

    [SerializeField] AudioSource sfx;
    [SerializeField] AudioClip[] audioClips;
    [SerializeField] TMP_Text health;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask street;
    [SerializeField] LayerMask countryRoad;
    [SerializeField] playerMenu menu;
    [SerializeField] GameObject highScore;


    public int hp = 100;
    bool end = false;

    public void pickUpSfx()
    {
        sfx.PlayOneShot(audioClips[0], 2);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("street"))
        {
            multiplier = 1f;
        }else if (other.CompareTag("timer") && !stopwatchActive)
        {
            stopwatchActive = true;
        }else if(other.CompareTag("timer") && stopwatchActive && !end)
        {
            stopwatchActive = false;
                end = true;
            pauseGameCompleted();
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            hp -= 1;
        }
    }

    void pauseGameCompleted()
    {
        int x = (int) currentTime;

        Time.timeScale = 0.1f;
        statsMenu.SetActive(true);
        timeText.text = x.ToString();
        enemies.text = killedEnemies.ToString();
        nuts.text = handler.nutsSold.ToString();


        int y = points - x;
        totalPoints.text = y.ToString();

        int i = PlayerPrefs.GetInt("Highscore");
        if(y > i)
        {
            PlayerPrefs.SetInt("Highscore", y);
            highScore.SetActive(true);
        }
        menu.finish();

    }

    private void Start()
    {
        mainCameraTransform = Camera.main.transform;
        cameraOffset = mainCameraTransform.position - transform.position;
    }

    void Update()
    {
        points = killedEnemies * 15 + handler.nutsSold * 10;
        text.text = points.ToString();
        health.text = hp.ToString();
        movement();
        shooting();
        if(handler.nuts > 100)
        {
            speed = 3f;
        }
        else if(handler.nuts > 80)
        {
            speed = 4f;
        }else if(handler.nuts > 60)
        {
            speed = 5f;
        }else if(handler.nuts > 40)
        {
            speed = 5.5f;
        }else if(handler.nuts > 20)
        {
            speed = 6f;
        }
        else if(handler.nuts > 10)
        {
            speed = 7f;
        }

        if (stopwatchActive == true)
        {
            currentTime = currentTime + Time.deltaTime;
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        currentTimeText.text = time.ToString(@"mm\:ss\:fff");

        check();

    }

    void check()
    {
        RaycastHit hit;
        if (Physics.CheckSphere(transform.position, 2, street))
        {
            multiplier = 2f;
        }else if(Physics.CheckSphere(transform.position, 2, countryRoad))
        {
            multiplier = 1.5f;
        }
        else
        {
            multiplier = 1f;
        }
    }

    void shooting()
    {
        if (Input.GetButton("Fire2"))
        {
            hand1.transform.position = shootingPos.position;

            if (Input.GetButtonDown("Fire1") && handler.nuts > 0)
            {
                GameObject x = Instantiate(nutThrow, throwPos.transform.position, throwPos.transform.rotation);
                Rigidbody rb = x.GetComponent<Rigidbody>();
                rb.AddForce(hand1.transform.forward * 1000);
                handler.nuts--;
                sfx.PlayOneShot(audioClips[1], 2);
            }
        }
        else
        {
            hand1.transform.position = oldPos.position;
        }
    }

    void movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (!controller.isGrounded) 
        {
            Vector3 pushVector = new Vector3(0.0f, -pushForce, 0.0f); 

            controller.Move(pushVector * Time.deltaTime); 
        }

        // Calculate the movement vector
        Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput);
        movement = Vector3.ClampMagnitude(movement, 1.0f); 

        if (movement != Vector3.zero) 
        {
            playerCapsule.transform.rotation = Quaternion.Slerp(playerCapsule.transform.rotation, Quaternion.LookRotation(movement), 0.15F);
        }

        controller.Move(movement * speed * multiplier * Time.deltaTime);

        Vector3 cameraTargetPosition = transform.position + cameraOffset;

        mainCameraTransform.position = Vector3.Lerp(mainCameraTransform.position, cameraTargetPosition, cameraFollowSpeed * Time.deltaTime);

    }

}