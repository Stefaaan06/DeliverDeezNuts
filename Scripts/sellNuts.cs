using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sellNuts : MonoBehaviour
{
    [SerializeField] nutHandler handler;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("shop"))
        {
            if(Input.GetKey(KeyCode.E))
            {
                delivery del = other.GetComponent<delivery>();

                if(handler.nuts > 0 && del.demand > 0)
                {
                    handler.nuts -= 1;
                    del.demand -= 1;
                    handler.nutsSold += 1;
                }
                
            }
        }
    }
}
