using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    public int attackDamage = 100;
    public float attackSpeed = 0.5f;
    public float distance;
    public AudioClip attackEff;

    float timer;
    Animator anim;
    AudioSource attackAudio;
    ParticleSystem attackParticles;
    bool enemyInRange;
    EnemyHealth enemyHealth;
    GameObject enemy;
    GameObject[] gameObjs;

    // Use this for initialization
    void Awake () {
        attackAudio = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        enemyInRange = false;
    }

    // Update is called once per frame
    void Update () {
       
            timer += Time.deltaTime;        

        if (Input.GetMouseButton(0) && (timer >= attackSpeed) && (Time.timeScale != 0))
        {
            Attack();
        }
	}


    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            enemyInRange = true;
            other.gameObject.GetComponent<EnemyHealth>().setInRange();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemyInRange = false;
            other.gameObject.GetComponent<EnemyHealth>().setNotInRange();
        }
        

    }

    void Attack()
    {

        anim.SetTrigger("Attack");

        gameObjs = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemyInRange == true)
        {
            foreach(GameObject enemy in gameObjs)
            {
                EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();

                if(enemyHealth.inRange == true)
                {
                    enemyHealth.TakeDamage(attackDamage);
                }
                
            }
        }
    }
}
