using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
