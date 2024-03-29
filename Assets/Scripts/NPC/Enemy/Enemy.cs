using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    Animator animator;

    public int health = 100;
    public int damage = 5;

    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;


    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPositionRange;


    //Atacking
    private float timeBetweenAttacks;
    bool alreadyAtacked;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, PlayerInAttackRange;
    private bool isDead = false;

    public List<GameObject> drop = new();

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }




    // Update is called once per frame
    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        PlayerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !PlayerInAttackRange && !isDead) Patroling();
        if (playerInSightRange && !PlayerInAttackRange && !isDead) ChasePlayer();
        if (playerInSightRange && PlayerInAttackRange && !isDead) AttackPlayer();

        if (health <= 0 && !isDead)
        {
            isDead = true;
            Death();
        }
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
        {
            animator.SetBool("Walk Forward", true);
            agent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        float randomZ = UnityEngine.Random.Range(-walkPositionRange, walkPositionRange);
        float randomX = UnityEngine.Random.Range(-walkPositionRange, walkPositionRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }

    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
        animator.SetBool("Walk Forward", true);
    }

    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
        animator.SetBool("Walk Forward", false);
        animator.SetTrigger("Stab Attack");
        timeBetweenAttacks = animator.GetCurrentAnimatorStateInfo(0).length;


        if (!alreadyAtacked)
        {
            player.gameObject.GetComponent<PlayerStats>().health -= damage;
            alreadyAtacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAtacked = false;
    }

    private void Death()
    {
        animator.SetTrigger("Die");
    }
}
