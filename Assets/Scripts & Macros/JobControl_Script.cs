using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JobControl_Script : MonoBehaviour
{
    [Header("Debug UI")]
    public Text jobRole;
    public Slider produceSlider;
    public Slider storedAmount;
    public Text storedText;
    public Text currentJobState;

    [Header("Job Services")]
    public GameObject cartObject;

    [Header("Assigned NPC's")]
    public GameObject[] assignedCharacters;

    [Header("Produce Values")]
    public int amountStored;

    private bool enableCart = false;
    public AssignCollection_Script collectionScript;
    public StatsController_Script statsScript;

    public GameObject clientLocation;
    public bool passedInfo;

    private void Awake()
    {
        collectionScript = GetComponentInChildren<AssignCollection_Script>();

        if (gameObject.name == "JobBench(Collection)")
        {
            enableCart = true;
            //CartService();
        }
        else if (gameObject.name == "JobBench(Produce)")
        {
            enableCart = false;
        }
    }

    void Update()
    {
        amountStored = (int)storedAmount.value;
        if(storedText != null)
        {
            storedText.text = "" + amountStored;
            storedAmount.value = amountStored;
        }

        if (passedInfo)
        {
            Debug.Log("Working");
            CartService();
        }
    }

    void CartService()
    {
        passedInfo = false;
        Transform currentJobLocation = gameObject.transform;
        GameObject cart = Instantiate(cartObject, currentJobLocation.position, Quaternion.identity);
        cart.transform.parent = gameObject.transform;

        for (int i = 0; i < assignedCharacters.Length; i++)
        {
            statsScript = assignedCharacters[i].GetComponent<StatsController_Script>();           
            statsScript.AssignWorkplace(gameObject.transform);
            statsScript.AssignCollectionPoint(collectionScript.collectionPoint.transform);
            clientLocation = collectionScript.collectionPoint;
        }
    }

        //clientLocation = collectionScript.collectionPoint;
    

    public void OffloadProduce()
    {
        amountStored = 0;
        storedAmount.value = amountStored;
    }

    public void OnTriggerStay(Collider collider)
    {
        if (!enableCart && collider.tag == "Entity")
        {
            if (produceSlider.value < 100)
            {
                //produceSlider.value += 0.01f;
                produceSlider.value += 1f;
            }
            else
            {
                storedAmount.value += 1;
                produceSlider.value = 0;       
            }
        }
        else if (!enableCart && collider.tag == "Cart")
        {

        }
    }
}
