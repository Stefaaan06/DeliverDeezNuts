using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
/// <summary>
/// Manages the Enemy
/// @author Stefaaan
/// @version 1.1 -added documentation
/// </summary>
public class enemyScript : MonoBehaviour
{
    public Transform player; 
    public float followDistance = 5f; 

    public NavMeshAgent agent; 
    public float distanceToPlayer;

    public GameObject face;
    public GameObject angry;
    public GameObject dead;
    public TMP_Text name;

    bool dontFollow;
    public bool tutorial;

    public GameObject deadEnemy;

    private void Update()
    {
        //pathfinding
        if (tutorial) return;
        if(dontFollow) return;
       
        distanceToPlayer = Vector3.Distance(transform.position, player.position);

       
        if (distanceToPlayer < followDistance)
        {
            agent.isStopped = false;
            agent.SetDestination(player.position);
            name.text = "Nutchaser";
            face.SetActive(false);
            angry.SetActive(true);
        }
        else
        {
            
            agent.isStopped = true;
            name.text = "Sleeping Nutchaser";
            face.SetActive(true);
            angry.SetActive(false);
        }
    }
    public void die()
    {
        Vector3 pos = transform.position;
        Quaternion rot = transform.rotation;
        Instantiate(deadEnemy, pos, rot);
        

        Destroy(this.gameObject);
    }

}

