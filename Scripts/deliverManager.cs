using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class deliverManager : MonoBehaviour
{
    [SerializeField] delivery[] del;
    [SerializeField] Slider[] slider;

    int num = 0;
    private void Start()
    {
        foreach(delivery delivery in del)
        {
            slider[num].interactable = false;
            slider[num].value = delivery.price; num++;
            slider[num].interactable = false;
            slider[num].value = delivery.demand; num++;
        }
    }
}
