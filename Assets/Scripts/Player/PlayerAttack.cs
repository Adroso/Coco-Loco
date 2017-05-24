using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    public int attackDamage = 100;
    public float attackSpeed = 0.5f;
    public float distance;

    float timer;
    Animator anim;
    AudioSource attackAudio;
    ParticleSystem attackParticles;
    bool enemyInRange;
    EnemyHealth enemyHealth;
    GameObject enemy;
    Ray castRay = new Ray();
  
   

    // Use this for initialization
    void Awake () {
        attackAudio = GetComponent<AudioSource>();
        //enemyHealth = enemy.GetComponent<EnemyHealth>();
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
        enemy = GameObject.FindGameObjectWithTag("Enemy");

        timer += Time.deltaTime;

        

        if (Input.GetMouseButton(0) && (timer >= attackSpeed) && (Time.timeScale != 0))
        {
            Attack();
        }
	}

    void Attack()
    {             
        anim.SetTrigger("Attack");
        //enemy = GameObject.FindGameObjectWithTag("Enemy");
        //EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();

        RaycastHit hit;
        castRay.origin = transform.position;
        castRay.direction = transform.forward;

        if (Physics.Raycast(castRay, out hit))
        {
            EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(attackDamage);
            }
            distance = hit.distance;
            
        }



            timer = 0f;

        //attackAudio.Play();

        //if (enemyHealth == null && enemyInRange)
        //{
        //    //attackParticles.Stop();
        //    //attackParticles.Play();

        //    enemyHealth.TakeDamage(attackDamage);
        //}
    }
}
