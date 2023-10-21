using UnityEngine;

/// <summary>
/// Makes obj always face player camera
/// @author Stefaaan
/// @version 1.1 -added documentation
/// </summary>
public class FacePlayer : MonoBehaviour
{
    public Transform player; 

    public void Start()
    {
        if(player == null)
        {
            player = FindObjectOfType<Camera>().transform;
        }
    }

    private void Update()
    {
        
        transform.LookAt(player);
        transform.rotation *= Quaternion.Euler(0, 180, 0);
    }
}