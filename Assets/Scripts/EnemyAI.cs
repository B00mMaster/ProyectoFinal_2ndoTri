using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent _agent; 

    [SerializeField] private Transform player;

    private float visionRange=10f;
    private float attackRange=1f;

    private bool playerInVisionRange;
    private bool playerInAttackRange;

    [SerializeField] private LayerMask playerLayer;

    //Patrulla
    [SerializeField] private Transform[] waypoints;
    private int totalWaypoints;
    private int nextPoint;

    //Attack
    [SerializeField] private GameObject fireball;
    private float timeBetweenAtttacks = 2f;
    private bool canAttack=false;
    [SerializeField]private float upAttackForce = 15f;
    [SerializeField]private float forwardAttackForce = 18f;
    [SerializeField] private Transform spawnPoint;


    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        totalWaypoints = waypoints.Length;
        nextPoint = 1;
    }

    private void Update()
    {
        Vector3 pos = transform.position;
        playerInVisionRange = Physics.CheckSphere(pos, visionRange, playerLayer);
        playerInAttackRange = Physics.CheckSphere(pos, attackRange, playerLayer);

        if(!playerInVisionRange && !playerInAttackRange)
        {
            Patrol();
        }

        if(playerInVisionRange && !playerInAttackRange)
        {
            Chase();
        }

        if(playerInVisionRange && playerInAttackRange)
        {
            Attack();
        }
       
       // _agent.SetDestination(destiation.position);
    }

    private void Patrol()
    {
       if(Vector3.Distance(transform.position, waypoints[nextPoint].position)<2.5f)
       {
            nextPoint++;
            if(nextPoint==totalWaypoints)
            {
                nextPoint = 0;
            }
            transform.LookAt(waypoints[nextPoint].position);
       }
       
        _agent.SetDestination(waypoints[nextPoint].position);
    }

    private void Chase()
    {
        _agent.SetDestination(player.position);
        transform.LookAt(player);
    }

    private void Attack()
    {
        _agent.SetDestination(transform.position);
        
        if(canAttack)
        {
            /*Rigidbody rb = Instantiate(fireball, spawnPoint.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward*forwardAttackForce, ForceMode.Impulse);
            rb.AddForce(transform.up * upAttackForce, ForceMode.Impulse);*/

            canAttack = false;
            StartCoroutine(AttackCooldown());
        }
    }

    private IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(timeBetweenAtttacks);
        canAttack = true;
    }

    private void OnDrawGizmos()
    {
        //Esfera de visión
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, visionRange);

        //Esfera de ataque
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, visionRange);
    }
}
