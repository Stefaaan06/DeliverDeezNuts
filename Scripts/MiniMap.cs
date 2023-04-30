using UnityEngine;

public class MiniMap : MonoBehaviour
{
    public Transform player; 
    public Camera minimapCamera; 
    public float minimapSize = 10f;
    public Camera playerCamera;
    [SerializeField] GameObject map;

    private void Start()
    {
        minimapCamera.enabled = false;
    }

    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            minimapCamera.enabled = true;
            playerCamera.enabled = false;
            map.SetActive(true);
        }
        else if(Input.GetKeyUp(KeyCode.Tab))
        {
            minimapCamera.enabled = false;
            playerCamera.enabled = true;
            map.SetActive(false);
        }
    }
}