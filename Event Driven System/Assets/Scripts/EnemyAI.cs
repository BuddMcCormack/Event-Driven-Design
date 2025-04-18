using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    // Get reference to navmesh agent
    public NavMeshAgent agent;

    // Transform for player
    public Transform player;


    // Renderer for state color changes
    Renderer render;

    // Layer masks to determine what is floor and what is the player.
    public LayerMask whatIsFloor;
    public LayerMask whatIsPlayer;

    // Patrol Code Variables
    public Vector3 navPoint;
    bool navPointSet;
    public float navPointRange;

    // Attack Code Variables
    public float attackInterval;
    bool alreadyAttacked;
    public GameObject projectile;

    //States
    public float sightTriggerRange;
    public float attackTriggerRange;

    public bool playerInSightTriggerRange;
    public bool playerInAttackTriggerRange;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //Do checks for sight and attack trigger range
        playerInSightTriggerRange = Physics.CheckSphere(transform.position, sightTriggerRange, whatIsPlayer);
        playerInAttackTriggerRange = Physics.CheckSphere(transform.position, attackTriggerRange, whatIsPlayer);

        // If the player is not seen and not within attack range, the enemy will patrol.
        if (!playerInSightTriggerRange && !playerInAttackTriggerRange)
        {
            PatrolState();
        }

        // If the player is seen and not within attack range, the enemy will chase the player.
        if (playerInSightTriggerRange && !playerInAttackTriggerRange)
        {
            ChaseState();
        }

        // If the player is seen and within attack range, the enemy will attack the player.
        if (playerInSightTriggerRange && playerInAttackTriggerRange)
        {
            AttackState();
        }
    }


    // PATROL STATE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    private void PatrolState()
    {
        render = GetComponent<Renderer>();
        render.material.color = Color.green;
        if (!navPointSet)
        {
            SearchNavPoint();
        }

        if (navPointSet)
        {
            agent.SetDestination(navPoint);
        }

        // Calculate distance to navigational point.
        Vector3 distanceToNavPoint = transform.position - navPoint;

        // Once navigational point is reached, new navigational point is set automatically.
        if (distanceToNavPoint.magnitude < 1f)
        {
            navPointSet = false;
        }
    }

    // Calculate a navigational point within the map.
    private void SearchNavPoint()
    {
        float randomZ = Random.Range(-navPointRange, navPointRange);
        float randomX = Random.Range(-navPointRange, navPointRange);

        navPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        // Check if the navigational point is on the floor
        if (Physics.Raycast(navPoint, -transform.up, 2f, whatIsFloor))
        {
            navPointSet = true;
        }
    }

    // CHASE STATE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    private void ChaseState()
    {
        // Set color of enemy to yellow to visually indicate chase state
        render = GetComponent<Renderer>();
        render.material.color = Color.yellow;

        // Enemy position is set to navigate to the player position
        agent.SetDestination(player.position);
    }


    // ATTACK STATE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    private void AttackState()
    {
        // Change the color of the enemy to red while attacking
        render = GetComponent<Renderer>();
        render.material.color = Color.red;

        // Instatiate a projectile that doesn't spin, add 16f forward force so it shoots forward
        Rigidbody rb = Instantiate(projectile,transform.position, Quaternion.identity).GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 16f, ForceMode.Impulse);


        // Freeze the enemy and make them face the player to attack
        agent.SetDestination(transform.position);
        transform.LookAt(player);

        // If the player already attacked, reset once attack interval has ended
        if (!alreadyAttacked)
        {

            alreadyAttacked = true;
            Invoke(nameof(ResetAttackState), attackInterval);
        }
    }

    private void ResetAttackState()
    {
        alreadyAttacked = false;
    }


    // Editor gizmo spheres which vizualize attack and sight ranges
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackTriggerRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightTriggerRange);

    }
}
