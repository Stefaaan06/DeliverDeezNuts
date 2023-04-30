using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class delivery : MonoBehaviour
{
    [SerializeField] int maxDemand;
    [SerializeField] int minDemand = 10;

    [SerializeField] int maxPrice;
    [SerializeField] int minPrice = 10;

    public int price;
    public int demand;

    void Awake()
    {
        price = Random.Range(minPrice, maxPrice);
        demand = Random.Range(minDemand, maxDemand);
    }
}
