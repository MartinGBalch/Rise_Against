using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    public GameObject player;            // Gameobject of the player goes here.
    public float attackRange;            // Once the enemy reaches this distance from the player, perform an attack action.
    public float aggroDistance;          // The radius that the player must enter for the enemy to act agressively towards the player.
    public float maxTravelRange;         // The max distance that the enemy will chase the player from its starting point.
    public int dodgeChance;
    public int blockChance;
    public bool AbleToBlock = false;
    private float maxTravelRangeHolder;  // Saves the max travel range variable;
    private float distToTarget;                  // The distance between the player and enemy, used to determined whether or not the enemy will act towards the player.
    private float distToStart;           // The distance between the start position and the current enemy position, used to determine when the enemy will return its starting point.
    private float HP;
    private Vector3 startingPosition;    // The enemy's start position.
    NavMeshAgent agent;                  // The enemy's NavMesh agent, assigned in Start().
    Animator anim;                       // The animator for the enemy, assigned in Start().
    public bool IsAttacking = false;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();           // Set the NavMesh agent.
        startingPosition = agent.transform.position;    // Set the enemy's starting position.
        maxTravelRangeHolder = maxTravelRange;          // Save the the max travel range.
        anim = GetComponent<Animator>();                // Set the animator.
    }


    void Update()
    {

        distToTarget = Vector3.Distance(agent.transform.position, player.transform.position);   // Determine the distance to the player.
        distToStart = Vector3.Distance(agent.transform.position, startingPosition);     // Determine the distance to the starting position.
        HP = GetComponent<Health>().HealthValue;
        

        if (aggroDistance >= distToTarget && distToStart <= maxTravelRange && HP > 0)     // If the player is in range to be acted upon and the enemy is within the maximum range from its starting position do the following:
        {
            anim.SetBool("IsAttacking", false);
            anim.SetBool("IsWalking", true);
            agent.transform.LookAt(player.transform);                 // Look at the player.
            if (distToTarget >= attackRange)                             // If the enemy is not within attacking range,
                agent.destination = player.transform.position;        // Move closer to the player until within attacking range.
        }
        else                                                          // If the enemy moves outside of the max radius from the starting position, return to the starting position.
        {
            anim.SetBool("IsAttacking", false);
            anim.SetBool("IsWalking", true);
            maxTravelRange = 1;                                       // The enemy will ignore the player until it reaches the starting point again
            agent.destination = startingPosition;
            if (distToStart <= 2)                                     // Once the enemy returns to its starting position, reset the max travel range to the previously set range.
            {
                anim.SetBool("IsWalking", false);
                maxTravelRange = maxTravelRangeHolder;
            }
        }

        if (distToTarget <= attackRange && HP > 0)                               // If within attacking range and is still alive, the enemy will attack
        {
            IsAttacking = true;
            agent.destination = agent.transform.position;
            anim.SetBool("IsWalking", false);
            GetComponent<AIAttack>().Attack();
        }
        else { IsAttacking = false; }

        if (HP <= 0)                                                  // Condition to stop the enemy from moving, also added HP > 0 condition to the previous 'if' statements to prevent rotation and attack animations while dead
        {
            agent.destination = transform.position;
        }

        // COMMENTED OUT UNTIL ANIMATIONS ARE READY TO BE IMPLEMENTED FOR DODGING AND BLOCKING
        //if(player.GetComponent<SwordRotations>().Xbutton == true || player.GetComponent<SwordRotations>().YcomboTree == true && HP > 0)
        //{
        //    int rand = Random.Range(1, 100);
        //    if (rand <= dodgeChance)
        //        anim.SetBool("IsDodging", true);
        //    if (AbleToBlock == true)
        //        if (rand > dodgeChance && rand <= (dodgeChance + blockChance))
        //            anim.SetBool("IsBlocking", true);                
        //}
    }
}
