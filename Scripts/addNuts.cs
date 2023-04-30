using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addNuts : MonoBehaviour
{
    [SerializeField] nutHandler nutHandler;

    public void addAmount(int nuts)
    {
        nutHandler.nuts += nuts;
    }
}
