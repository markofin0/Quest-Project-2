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

    private bool isBeingPat = false; 

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        // 3
        InitializePatrolRoute();

        MoveToNextPatrolLocation();

        anim = GetComponent<Animator>();
        anim.SetBool("isWalking", true);
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
        if(agent.remainingDistance < 0.2f && !agent.pathPending)
        {
            MoveToNextPatrolLocation();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            StartCoroutine(patCat());
        }

    }

    public IEnumerator patCat()
    {
        isBeingPat = true;
        anim.SetBool("isWalking", false);
        anim.SetBool("isSitting", true);
        agent.isStopped = true;

        yield return new WaitForSeconds(5);

        isBeingPat = false;
        anim.SetBool("isSitting", false);
        anim.SetBool("isWalking", true);
        agent.isStopped = false;
        MoveToNextPatrolLocation();
    }




}
