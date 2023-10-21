using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Makes Npc always face player
/// @author Stefaaan
/// @version 1.1 -added documentation
/// </summary>
public class npcFacePlayer : MonoBehaviour
{
    public Transform player; 

    private void Start()
    {
        if(player == null)
        {
            player = FindObjectOfType<PlayerController>().transform;
        }
    }

    private void Update()
    {
        transform.LookAt(player);
    }
}
