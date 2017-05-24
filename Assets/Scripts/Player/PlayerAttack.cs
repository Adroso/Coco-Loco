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
    GameObject[] gameObjs;



    // Use this for initialization
    void Awake () {
        attackAudio = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        enemyInRange = false;
        //enemyHealth = enemy.GetComponent<EnemyHealth>();
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
            //Debug.Log("In Range");
            //EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
            //enemyHealth.TakeDamage(attackDamage);

            foreach(GameObject go in gameObjs)
            {
                EnemyHealth enemyHealth = go.GetComponent<EnemyHealth>();

                if(enemyHealth.inRange == true)
                {
                    enemyHealth.TakeDamage(attackDamage);
                }
                
            }
        }
        else
        {
            //Debug.Log("Not In Range");
            
        }
        

    }

    void Attackold()
    {             
        //anim.SetTrigger("Attack");
        //enemy = GameObject.FindGameObjectWithTag("Enemy");
        //EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();

        RaycastHit hit;
        castRay.origin = transform.position;
        castRay.direction = transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward), Color.green);

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

        if (enemyHealth == null && enemyInRange)
        {
            //attackParticles.Stop();
            //attackParticles.Play();

            enemyHealth.TakeDamage(attackDamage);
        }
    }
}
