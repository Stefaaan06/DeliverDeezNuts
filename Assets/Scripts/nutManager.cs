using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages Player Nuts
/// @author Stefaaan
/// @version 1.1 -added documentation
/// </summary>
public class nutManager : MonoBehaviour
{
    public float amplitude = 1.0f; 
    public float frequency = 1.0f; 

    private float startY; 

    private void Start()
    {
        startY = transform.position.y; 
    }

    
    void Update()
    {
        float newY = startY + amplitude * Mathf.Sin(frequency * Time.time); 

        transform.position = new Vector3(transform.position.x, newY, transform.position.z); 
    }
}
