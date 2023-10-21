using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


/// <summary>
/// Replaces enemy with dead enemy which has a rb
/// @author Stefaaan
/// @version 1.1 -added documentation
/// </summary>
public class dieScriptEnemy : MonoBehaviour
{
    [SerializeField] TMP_Text m_Text;
    [SerializeField] GameObject deadFace;
    [SerializeField] GameObject aliveFace;
    public void die()
    {
        this.gameObject.AddComponent<Rigidbody>();
        m_Text.text = "knocked out Nutchaser";
        deadFace.SetActive(true); 
        aliveFace.SetActive(false);
    }
}
