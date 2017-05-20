using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    Rigidbody playerRigidbody;
    Vector3 movement;
    public float speed = 6f;
    int floorMask;

    private void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        //anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        float mouseInput = Input.GetAxis("Mouse X");
        Vector3 lookhere = new Vector3(0, mouseInput, 0);
        transform.Rotate(lookhere);

        if (Input.GetKey(KeyCode.A))
        {
            moveLeft(speed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveRight(speed);
        }

        if (Input.GetKey(KeyCode.W))
        {
            moveForward(speed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            scootBack(speed);
        }

        //if (playerRigidbody != colliding with terrain) {
        //    gravity += 100;
        //}
     
    }

    void moveRight(float speed)
    {
        transform.localPosition += transform.right * speed * Time.deltaTime;
    }

    void moveLeft(float speed)
    {
        transform.localPosition -= transform.right * speed * Time.deltaTime;
    }

    void moveForward(float speed)
    {
        transform.localPosition += transform.forward * speed * Time.deltaTime;
    }

    void scootBack(float speed)
    {
        transform.localPosition -= transform.forward * speed * Time.deltaTime;
    }

    //void Move(float h, float v)
    //{
    //    movement.Set(h, 0f, v);
    //    movement = movement.normalized * speed * Time.deltaTime;
    //    playerRigidbody.MovePosition(transform.position + movement);
    //}
}
