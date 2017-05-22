using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    Rigidbody playerRigidbody;
    Vector3 movement;
    public float speed = 6f;
    int floorMask;
    public bool isMoving;
    Animator anim;
    

    private void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            attackAnimate();
        }
    }

    private void FixedUpdate()
    {
        Animating(false);
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        float mouseInput = Input.GetAxis("Mouse X");
        Vector3 lookhere = new Vector3(0, mouseInput, 0);
        transform.Rotate(lookhere);
        

        if (Input.GetKey(KeyCode.A))
        {
            moveLeft(speed);
            Animating(true);

        }

        if (Input.GetKey(KeyCode.D))
        {
            moveRight(speed);
            Animating(true);

        }

        if (Input.GetKey(KeyCode.W))
        {
            moveForward(speed);
            Animating(true);

        }

        if (Input.GetKey(KeyCode.S))
        {
            scootBack(speed);
            Animating(true);

        }
     
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

    void Animating (bool moving)
    {
        anim.SetBool("isMoving", moving);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Water")
        {
            anim.SetTrigger("Die");
        }
    }

    private void attackAnimate()
    {
        anim.SetTrigger("Attack");
    }
}
