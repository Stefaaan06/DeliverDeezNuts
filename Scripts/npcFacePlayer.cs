using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
