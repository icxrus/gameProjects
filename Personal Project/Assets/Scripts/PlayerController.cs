using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameObject Planet;
    public GameObject PlayerPlaceholder;


    public float speed;
    public float turnSpeed;
    public float softening;

    private float gravity = 100;
    private bool OnGround = false;


    float distanceToGround;
    Vector3 Groundnormal;

    private float horizontalInput;
    private float forwardInput;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        // Get rigidbody
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        // Lock cursor to center of screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {


        // Get input
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        // Movement
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);




        // Speed boost

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 6;
        }
        else
        {
            speed = 4;
        }

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


   


}