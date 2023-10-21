using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages enemy spawning
/// @author Stefaaan
/// @version 1.1 -added documentation
/// </summary>
public class spawnEnemies : MonoBehaviour
{
    public GameObject[] enemies;

    private void Start()
    {
        foreach(GameObject enemy in enemies)
        {
            int x =Random.Range(0, 3);
            if(x == 0)
            {
                Destroy(enemy);
            }
        }
    }
}
