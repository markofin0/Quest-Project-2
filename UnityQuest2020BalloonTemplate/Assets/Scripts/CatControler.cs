using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CatControler : MonoBehaviour
{
    // Using code from the book for the patrolRoute
    public Transform patrolRoute;

    public List<Transform> locations;

    private int loacationIndex = 0;

    private Animator anim;

    private NavMeshAgent agent;

    // gameobject to store the player, so that it can start to follow them
    public GameObject player; 

    public bool playerInSphere = false;

    // boolean to track if the pet has been fed a treat, after which they will start to follow the player
    public bool hasEaten;

    // Stopping distance for the navmesh 
    public float stoppingDistance; 

    public GameManagerScript gameManagerScript;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        InitializePatrolRoute();

        MoveToNextPatrolLocation();

        anim = GetComponent<Animator>();
        anim.SetBool("isWalking", true);

        hasEaten = false;
    }


    void InitializePatrolRoute()
    {
       
        foreach (Transform child in patrolRoute)
        {
          
            locations.Add(child);
        }
    }

    void MoveToNextPatrolLocation()
    {
        if (locations.Count == 0) return;
        agent.destination = locations[loacationIndex].position;
        loacationIndex = (loacationIndex + 1) % locations.Count;
    }

    private void Update()
    {
        if (hasEaten)
        {
            agent.destination = player.transform.position;
            agent.stoppingDistance = stoppingDistance;

        }
        else if (agent.remainingDistance < 0.2f && !agent.pathPending && !playerInSphere)
        {
            MoveToNextPatrolLocation();
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerInSphere = true;
            anim.SetBool("isWalking", false);
            anim.SetBool("isSitting", true);
            agent.isStopped = true;
            agent.velocity = Vector3.zero;
        }

    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // bit of code to make it so the cat will follow the player after its eaten.
            playerInSphere = false;
            if (!hasEaten)
            {
                agent.isStopped = false;
                anim.SetBool("isSitting", false);
                anim.SetBool("isWalking", true);
                MoveToNextPatrolLocation();
            }
            else
            {
                agent.isStopped = false;
                anim.SetBool("isSitting", false);
                anim.SetBool("isWalking", true);
                agent.destination = player.transform.position;
                agent.stoppingDistance = stoppingDistance;

            }
        }
    }
    // Method for use in the treat script
    public void eatTreat()
    {
        hasEaten = true;
        gameManagerScript.quests[1] = true; 
    }




}
