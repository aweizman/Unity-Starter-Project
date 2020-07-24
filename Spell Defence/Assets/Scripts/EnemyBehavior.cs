using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    // enemies will run towards player. if touch player, enemy is destroyed but player loses life.
    // Start is called before the first frame update
    Rigidbody enemyRb;
    GameObject player;
    public float speed;
    public float minDist; //can be changed farther so that enemies shoot spells at player from a distance.
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    private Vector3 playerDir; //direction of player from enemy position.
    void Update()
    {
        chasePlayer();
        //possibly add a cast spell at player method?
    }
    void chasePlayer()
    {
        transform.LookAt(player.transform);
        if (Vector3.Distance(transform.position, player.transform.position) >= minDist)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }
}
