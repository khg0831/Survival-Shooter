using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    private Transform player;
    private PlayerHealth PlayerHealth;
    private EnemyHealth enemyHealth;
    private NavMeshAgent nav;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        PlayerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();

        nav = GetComponent<NavMeshAgent>();
    }

    public void Update()
    {
        if (enemyHealth.currentHealth > 0 && PlayerHealth.currentHealth > 0)
        {
            nav.SetDestination(player.position);
        }
        else
        {
            nav.enabled = false;
        }
    }
}
