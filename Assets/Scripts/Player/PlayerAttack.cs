using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    public int attackDamage = 100;
    public float attackSpeed = 0.5f;

    float timer;
    Animator anim;
    AudioSource attackAudio;
    ParticleSystem attackParticles;
    bool enemyInRange;
    EnemyHealth enemyHealth;
    GameObject enemy;

    // Use this for initialization
    void Awake () {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        attackAudio = GetComponent<AudioSource>();
        enemyHealth = enemy.GetComponent<EnemyHealth>();
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == enemy)
        {
            enemyInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == enemy)
        {
            enemyInRange = false;
        }
    }

    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;

        if (Input.GetMouseButton(0) && (timer >= attackSpeed) && (Time.timeScale != 0))
        {
            Attack();
        }
	}

    void Attack()
    {             
        anim.SetTrigger("Attack");

        timer = 0f;

        //attackAudio.Play();

        if(enemyInRange)
        {

            //attackParticles.Stop();
            //attackParticles.Play();

            enemyHealth.TakeDamage(attackDamage);
        }
    }
}
