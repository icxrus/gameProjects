using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameObject Planet;
    public GameObject PlayerPlaceholder;
    public GameObject Canvas;
    private AudioSource audioSource;
    public AudioClip crash;
    public AudioClip scream;

    public float speed;
    private float turnSpeed = 40;
    private float softening = 4;

    private float gravity = 100;
    private bool OnGround = false;
    private bool Paused;

    float distanceToGround;
    Vector3 Groundnormal;

    private float horizontalInput;
    private float mouseXInput;

    private Rigidbody rb;

    void Start()
    {
        // Get Game over screen Canvas
        Canvas = GameObject.Find("Game Over Canvas");

        // Get rigidbody
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        // Lock cursor to center of screen
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Set the Planet center  point
        Planet = GameObject.Find("Planet Center");

        // De-Activate Game Over Canvas
        Canvas.gameObject.SetActive(false);
        Paused = false;

        
    }

    void Update()
    {
        //Start Speed up
        Invoke("SpeedUp", 10);

        // Get input
        horizontalInput = Input.GetAxis("Horizontal");
        mouseXInput = Input.GetAxis("Mouse X");

        // Movement
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
        transform.Rotate(Vector3.up, turnSpeed * mouseXInput * Time.deltaTime);

        speed = 4;

        // Play area
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -5f, 5f), transform.position.y, transform.position.z);

        //Ground control
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(transform.position, -transform.up, out hit, 10))
        {

            distanceToGround = hit.distance;
            Groundnormal = hit.normal;

            if (distanceToGround <= 0.2f)
            {
                OnGround = true;
            }
            else
            {
                OnGround = false;
            }


        }

        //Gravity and rotation

        Vector3 gravDirection = (transform.position - Planet.transform.position).normalized;

        if (OnGround == false)
        {
            rb.AddForce(gravDirection * -gravity);

        }

        // Softening for gravity

        Quaternion toRotation = Quaternion.FromToRotation(transform.up, Groundnormal) * transform.rotation;
        transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, softening * Time.deltaTime);
    }

    // Game End and collision sounds
    void OnCollisionEnter(Collision deathCol)
    {
        if (deathCol.collider.tag == "Rock")
        {
            Time.timeScale = 0.0f;
            Canvas.gameObject.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Paused = true;
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = crash;
            audioSource.Play();
        }
        if (deathCol.collider.tag == "Obstacle")
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = crash;
            audioSource.Play();
        }
        if (deathCol.collider.tag == "Human")
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = scream;
            audioSource.Play();
        }
    }

    //Speed increases over time
    void SpeedUp() 
    {
        if (speed < 10)
        {
            speed += 0.25f;
        }

        Invoke("SpeedUp", 10);
    }


}