using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Displays Price & Demand on UI
/// @author Stefaaan
/// @version 1.1 -added documentation
/// </summary>
public class deliverManager : MonoBehaviour
{
    [SerializeField] delivery[] del;
    [SerializeField] Slider[] slider;

    int num = 0;
    private void Start()
    {
        // goes trough each source and displays the values on the sliders
        foreach(delivery delivery in del)
        {
            slider[num].interactable = false;
            slider[num].value = delivery.price; num++;
            slider[num].interactable = false;
            slider[num].value = delivery.demand; num++;
        }
    }
}
