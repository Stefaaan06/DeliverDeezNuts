using System.Collections;
using TMPro;
using UnityEngine;

public class nutHandler : MonoBehaviour
{
    public int nuts = 0;
    [SerializeField] TMP_Text nutCounter;
    [SerializeField] Color errorCol;
    [SerializeField] PlayerController controller;

    Color oldCol;
    public bool gotNuts = false;

    public int nutsSold = 0;

    private void Start()
    {
        oldCol = nutCounter.color;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Nut"))
        {
            nuts++;
            Destroy(other.gameObject);
            controller.pickUpSfx();
        }
        else if (other.CompareTag("addNuts") && !gotNuts)
        {
            gotNuts = true;
            nuts += 15;
            controller.pickUpSfx();
        }
    }

    private void Update()
    {
        if(nuts <= 0)
        {
            noNuts();
        }
        else
        {
            normalNuts();
        }

        nutCounter.text = nuts.ToString();
    }

    public void noNuts()
    {
        nutCounter.color = errorCol;
    }

    void normalNuts()
    {
        nutCounter.color = oldCol;
    }
}
