using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoControls : MonoBehaviour
{
    public float turnSpeed = 4.0f;
    public Transform player;

    public float height = 1f;
    public float distance = 2f;

    private Vector3 offsetX;

    void Start()
    {

        offsetX = new Vector3(player.position.x, player.position.y + height, player.position.z + distance);
    }

    void LateUpdate()
    {
        offsetX = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offsetX;
        transform.position = player.position + offsetX;
        transform.LookAt(player.position);
    }
}
