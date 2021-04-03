using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartController_Script : MonoBehaviour
{
    public int cartContainAmount;
    public JobControl_Script jobScript;

    [Header("Cart Information")]
    private int amountStored;
    public bool offloadingProduce = false;
    
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "JobBench(Produce)")
        {
            jobScript = collider.GetComponent<JobControl_Script>();
            amountStored = jobScript.amountStored;

            if (amountStored > 0)
            {
                offloadingProduce = true;

                cartContainAmount += amountStored;
            }
            else
                offloadingProduce = false;
        }
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.name == "JobBench(Produce)" && offloadingProduce)
        {
            jobScript.OffloadProduce();
            //Debug.Log("Yep Ths Wrks");
            //jobScript.passedInfo = true;
            //cartContainAmount++; 
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        offloadingProduce = false;
    }
}
