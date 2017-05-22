using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    public float attackSpeed = 1.0f;
    public int attackDamage = 10;

    Animator anim;
    GameObject player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    bool playerInRange;
    float timer;

    // Use this for initialization
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        // If the entering collider is the player...
        if (other.gameObject == player)
        {
            // ... the player is in range.
            playerInRange = true;
        }
    }


    void OnTriggerExit(Collider other)
    {
        // If the exiting collider is the player...
        if (other.gameObject == player)
        {
            // ... the player is no longer in range.
            playerInRange = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("AttackPlayer", false);
        timer += Time.deltaTime;

        if (timer >= attackSpeed && playerInRange && enemyHealth.currentHealth > 0)
        {
            Attack();

        }

        if (playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger("Die");
            anim.SetTrigger("PlayerDead");
        }
       
    }

    void Attack()
    {
        timer = 0f;

        if (playerHealth.currentHealth > 0)
        {
            
            playerHealth.TakeDamage(attackDamage);
            anim.SetBool("AttackPlayer", true);
        }
       
    }

}
