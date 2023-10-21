using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// makes nav mesh agent follow player
/// @author Stefaaan
/// @version 1.1 -added documentation
/// </summary>
public class followPlayer : MonoBehaviour
{
    public Transform player;
    public float followDistance = 5f; 

    public NavMeshAgent agent; 
    public float distanceToPlayer;

    private void Update()
    {
        
        distanceToPlayer = Vector3.Distance(transform.position, player.position);

        
        if (distanceToPlayer > followDistance)
        {
            agent.isStopped = false;
            agent.SetDestination(player.position);
        }
        else
        {
            
            agent.isStopped = true;
        }
    }
}
