using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemymove : MonoBehaviour
{
    // Start is called before the first frame update
    Transform player;
    NavMeshAgent nav;
    playerhealth playerHealth;      // Reference to the player's health.
    enemyhealth enemyHealth;        // Reference to this enemy's health.
   // public bool iswalking;
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<playerhealth>();
        enemyHealth = GetComponent<enemyhealth>();
    }

    // Update is called once per frame
    void Update()
    {
        // If the enemy and the player have health left...
        if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        {
            // ... set the destination of the nav mesh agent to the player.
            nav.SetDestination(player.position);
           // iswalking = true;
        }
        // Otherwise...
        else
        {
            // ... disable the nav mesh agent.
            nav.enabled = false;
           // iswalking = false;
        }
    }
}
