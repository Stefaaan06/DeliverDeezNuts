using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class nutScript : MonoBehaviour
{

    public float shrinkSpeed = 0.1f;
    bool shrink = false;
    private Vector3 originalScale; 
    private void Start()
    {
        originalScale = transform.localScale;
        StartCoroutine(waitTillDeath());
    }


    IEnumerator waitTillDeath()
    {
        yield return new WaitForSeconds(3);
        shrink = true;
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }

    private void Update()
    {
        if (shrink)
        {
            Vector3 newScale = transform.localScale - (originalScale * shrinkSpeed * Time.deltaTime);
            transform.localScale = newScale;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("enemy"))
        {
            FindObjectOfType<PlayerController>().killedEnemies += 1;
            collision.gameObject.GetComponentInChildren<enemyScript>().die();
        }
    }
}
