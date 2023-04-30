using UnityEngine;

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