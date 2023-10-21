using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// adds nuts to player
/// @author Stefaaan
/// @version 1.1 -added documentation
/// </summary>
public class addNuts : MonoBehaviour
{
    [SerializeField] nutHandler nutHandler;

    public void addAmount(int nuts)
    {
        if(nutHandler.nuts < 100)
        {
            nutHandler.nuts += nuts;
        }
    }
}
