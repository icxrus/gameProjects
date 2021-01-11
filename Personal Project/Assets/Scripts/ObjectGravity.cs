using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGravity : MonoBehaviour
{

    //Remember to add box collider and rigidbody!

    public GameObject Planet;
    public int pointValue;

    float gravity = 10;
    bool OnGround = false;
    float speed = 100;


    float distanceToGround;
    Vector3 Groundnormal;


    private Rigidbody rb;
    private ScoreCount scoreCount;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Planet = GameObject.Find("Planet Center");
        scoreCount = GameObject.Find("Score Text").GetComponent<ScoreCount>();

    }


    void Update()
    {


        //GroundControl

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


        Quaternion toRotation = Quaternion.FromToRotation(transform.up, Groundnormal) * transform.rotation;
        transform.rotation = toRotation;


    }


    // Throws the object in a random direction on collision with player
    private void OnCollisionEnter(Collision dataFromCollision)
    {
        if (dataFromCollision.gameObject.name == "Player")
        {
            Vector3 direction = new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), Random.Range(-2f, 2f));
            Vector3 newVelocity = speed * direction;
            transform.GetComponent<Rigidbody>().velocity = newVelocity;

            scoreCount.UpdateScore(pointValue);

            // Destroy object after 2 seconds
            Object.Destroy(gameObject, 2.0f);
        }
    }
}
