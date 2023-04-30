using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NpcDialogSysem : MonoBehaviour
{
    [SerializeField] string[] convo;
    [SerializeField] TMP_Text text;
    public float delay = 0.1f; 
    private string currentText = "";  

    bool start = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !start)
        {
            StartCoroutine(startWrite());
            start = true;
        }
    }

    IEnumerator startWrite()
    {
        StartCoroutine(CwriteText(convo[0]));
        yield return new WaitForSeconds(3);
        if(convo.Length > 1)
        {
            StartCoroutine(CwriteText(convo[1]));
            yield return new WaitForSeconds(3);
            if (convo.Length > 2)
            {
                StartCoroutine(CwriteText(convo[2]));
                yield return new WaitForSeconds(3);
                if (convo.Length > 3)
                {
                    StartCoroutine(CwriteText(convo[3]));
                    yield return new WaitForSeconds(3);
                    if (convo.Length > 4)
                    {
                        StartCoroutine(CwriteText(convo[4]));
                        yield return new WaitForSeconds(3);
                        if (convo.Length > 5)
                        {
                            StartCoroutine(CwriteText(convo[5]));
                            yield return new WaitForSeconds(3);
                        }
                    }
                }
            }
        }

        StartCoroutine(CDeleteText(currentText));
    }

    IEnumerator CwriteText(string fullText)
    {
        for (int i = 0; i <= fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);    
            text.text = currentText;
            yield return new WaitForSeconds(delay);    
        }
    }

    IEnumerator CDeleteText(string fullText)
    {
        //typewriter animation
        for (int i = fullText.Length; i >= 0; i--)
        {
            currentText = fullText.Substring(0, i);     
            text.text = currentText;
            yield return new WaitForSeconds(delay); 
        }
    }
}
