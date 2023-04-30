using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
