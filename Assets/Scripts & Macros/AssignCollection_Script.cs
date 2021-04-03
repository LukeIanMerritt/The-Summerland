using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignCollection_Script : MonoBehaviour
{
    SphereCollider searchArea;
    bool foundProduce;
    public GameObject collectionPoint;
    public JobControl_Script jobScript;

    // Start is called before the first frame update
    void Start()
    {
        jobScript = GetComponentInParent<JobControl_Script>();
        searchArea = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!foundProduce)
        {
            searchArea.radius += 0.1f;
        }
    }

    public void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.name == "JobBench(Produce)")
        {
            jobScript.passedInfo = true;
            collectionPoint = collision.gameObject;
            foundProduce = true;
            gameObject.SetActive(false);
        }
    }
}
