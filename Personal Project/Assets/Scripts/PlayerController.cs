using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameObject Planet;
    public GameObject PlayerPlaceholder;


    public float speed;
    public float turnSpeed;
    public float JumpHeight = 1.2f;
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
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {


        // Get input
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);



        //Jump

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * 350 * JumpHeight * Time.deltaTime, ForceMode.Impulse);
        }

        // Speed boost

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 6;
        }
        else
        {
            speed = 4;
        }
        
     




        //Ground Control

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


        //GRAVITY and ROTATION

        Vector3 gravDirection = (transform.position - Planet.transform.position).normalized;

        if (OnGround == false)
        {
            rb.AddForce(gravDirection * -gravity);

        }

        //

        Quaternion toRotation = Quaternion.FromToRotation(transform.up, Groundnormal) * transform.rotation;
        transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, softening * Time.deltaTime);



    }


   


}