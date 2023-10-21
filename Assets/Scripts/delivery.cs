using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// generates price and demand for the different places
/// @author Stefaaan
/// @version 1.1 -added documentation
/// </summary>
public class delivery : MonoBehaviour
{
    //values that manage min & mix price/demand
    [SerializeField] int maxDemand;
    [SerializeField] int minDemand = 10;

    [SerializeField] int maxPrice;
    [SerializeField] int minPrice = 10;

    public int price;
    public int demand;

    void Awake()
    {
        //calculates price & demand
        price = Random.Range(minPrice, maxPrice);
        demand = Random.Range(minDemand, maxDemand);
    }
}
