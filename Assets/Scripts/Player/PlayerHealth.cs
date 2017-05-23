using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int startingHelath = 100;
    public int currentHealth;
    public int regeneration;
    public Slider healthSlider;
    public Image damageImage;
    public AudioClip deathClip;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    private float timestamp = 0f; //delays regen
    private float regenDelayTS = 0f; //delays regening health all at once


    Animator anim;
    AudioSource playerAudio;
    PlayerMovement playerMovement;
    bool isDead;
    bool damaged;

    // Use this for initialization
    void Awake()
    {
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        playerMovement = GetComponent<PlayerMovement>();
        currentHealth = startingHelath;
    }


    // Update is called once per frame
    void Update()
    {
        if (currentHealth < startingHelath &&(Time.time > (regenDelayTS + 2.0f)) && (Time.time > (timestamp + 10.0f))) //10 seconds after no damage and 2 seconds after last regen
        {
            currentHealth += regeneration;
            healthSlider.value = currentHealth;
            regenDelayTS = Time.time;
            timestamp = 0f;
        }

        if (damaged)
        {
            damageImage.color = flashColour;
            
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);

        }

        damaged = false;
    }

    public void TakeDamage(int amount)
    {
        damaged = true;
        currentHealth -= amount;
        healthSlider.value = currentHealth;
        timestamp = Time.time; // for regen
        //play hurt audio

        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }

    }

    void Death()
    {
        isDead = true;

        anim.SetTrigger("Die");

        //play death audio

        playerMovement.enabled = false;

    }
}
