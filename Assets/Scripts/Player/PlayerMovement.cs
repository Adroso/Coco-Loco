using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    Rigidbody playerRigidbody;
    PlayerHealth playerHealth;
    Vector3 movement;
    public float speed = 6f;
    int floorMask;
    public bool isMoving;
    Animator anim;
    public AudioClip runningClip;
    AudioSource source;



    private void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
        playerHealth = GetComponent<PlayerHealth>();
        source = GetComponent<AudioSource>();

    }

    private void FixedUpdate()
    {
        isMoving = false;
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
            isMoving = true;

        }

        if (Input.GetKey(KeyCode.D))
        {
            moveRight(speed);
            Animating(true);
            isMoving = true;

        }

        if (Input.GetKey(KeyCode.W))
        {
            moveForward(speed);
            Animating(true);
            isMoving = true;

        }

        if (Input.GetKey(KeyCode.S))
        {
            scootBack(speed);
            Animating(true);
            isMoving = true;

        }

        if (isMoving == true)
        {
            source.clip = runningClip;
            source.enabled = true;
            source.loop = true;
            

        }
        else
        {
            source.enabled = false;
            source.loop = false;

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

    void Animating (bool moving)
    {
        anim.SetBool("isMoving", moving);
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Water")
        {
            anim.SetTrigger("Die");
            //Kills Player
            playerHealth.TakeDamage(1000);
            
        }
    }
}
