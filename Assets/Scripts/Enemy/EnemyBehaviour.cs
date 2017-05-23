using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour {

    Transform player;
    public int speed;
    //PlayerHealth playerHealth;
    //EnemyHealth enemyHealth;
    NavMeshAgent nav;

	// Use this for initialization
	void Awake () {
        player = GameObject.Find("player").transform;
        //playerHealth = player.GetComponent<PlayerHealth>();
        //enemyHealth = GetComponent <EnemyHealth>():
        nav = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		//if (enemyHealth.currentHealth > 0 && PlayerHealth.currentHealth > 0) {
            nav.SetDestination(player.position);
        //}
        //else
        //{
        //    nav.enabled = false;
        //}
	}
}
