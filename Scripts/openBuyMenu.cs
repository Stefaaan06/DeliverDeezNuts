using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openBuyMenu : MonoBehaviour
{
    public GameObject menu; 

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            menu.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            menu.SetActive(false);
        }
    }
}
