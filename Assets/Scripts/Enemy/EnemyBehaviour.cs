using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour {

    Transform player;
    public int speed;
    NavMeshAgent nav;

	// Use this for initialization
	void Awake () {
        player = GameObject.Find("player").transform;
        nav = GetComponent<NavMeshAgent>();
        nav.speed = speed;
    }

    // Update is called once per frame
    void Update () {
            nav.SetDestination(player.position);
	}
}
